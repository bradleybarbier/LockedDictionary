using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const int SeedCallCount = 3;
        private bool _stopRequested;
        private int _callCounter;
        private int _requestCounter;
        private const int AddCallInterval = 1000;
        private const int DeleteCallInterval = 2000;
        private const int AddRequestInterval = 500;
        private const int ProcessRequestInterval = 250;
        private const int UiUPdateInterval = 1;

        //private int _totalCallsAdded = 0;
        private int _totalCallsDeleted = 0;

        public readonly Dictionary<int, Call> State = new Dictionary<int, Call>();
        public readonly Queue<Request> Requests = new Queue<Request>();
        private readonly Random _randomGenerator = new Random();

        private List<string> queuedTimerMessages = new List<string>();
        private List<string> queuedCallMessages = new List<string>();
        private List<string> queuedRequestMessages = new List<string>();

        #region Timers
        //Timer to add calls to state
        private Timer _timerAddCallToState;

        //Timer to delete calls from state
        private Timer _timerDeleteCallFromState;

        //Timer to add requests
        private Timer _timerAddRequest;

        //Timer to process requests
        private Timer _timerProcessRequest;

        //Timer to update UI
        private Timer _timerUiUpdate;
        #endregion

        private void SetupTimers()
        {
            _timerAddCallToState = new Timer {Interval = AddCallInterval }; // add new call
            _timerAddCallToState.Tick += HandleTimerAddCall;

            _timerDeleteCallFromState = new Timer {Interval = DeleteCallInterval }; // delete a call
            _timerDeleteCallFromState.Tick += HandleTimerDeleteCall;

            _timerAddRequest = new Timer {Interval = AddRequestInterval }; //add new request
            _timerAddRequest.Tick += HandleTimerAddRequest;

            _timerProcessRequest = new Timer {Interval = ProcessRequestInterval };  //process a request
            _timerProcessRequest.Tick += HandleTimerProcessRequest;

            _timerUiUpdate = new Timer { Interval = UiUPdateInterval };  //update UI
            _timerUiUpdate.Tick += HandleTimerUiUpdate;
        }

        #region Timer Handlers
        private async void HandleTimerAddCall(object sender, EventArgs e)
        //private void HandleTimerAddCall(object sender, EventArgs e)
        {
            try
            {
                queuedTimerMessages.Add("Add");
                await Task.Run(() =>
                {
                    AddRequest(Task.CurrentId, null, Operation.AddCall);
                });
                //AddRequest(Task.CurrentId, null, Operation.AddCall);
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private async void HandleTimerDeleteCall(object sender, EventArgs e)
        //private void HandleTimerDeleteCall(object sender, EventArgs e)
        {
            try
            {
                queuedTimerMessages.Add("Delete");
                await Task.Run(() =>
                {
                    AddRequest(Task.CurrentId, null, Operation.DeleteCall);
                });
                //AddRequest(Task.CurrentId, null, Operation.DeleteCall);
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private async void HandleTimerProcessRequest(object sender, EventArgs e)
        //private void HandleTimerProcessRequest(object sender, EventArgs e)
        {
            try
            {
                queuedTimerMessages.Add("Process");
                await Task.Run(() =>
                {
                    ProcessNextRequest();
                });

                //ProcessNextRequest();
                DoUiUpdate();
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private async void HandleTimerAddRequest(object sender, EventArgs e)
        //private void HandleTimerAddRequest(object sender, EventArgs e)
        {
            try
            {
                var randomCallId = GetRandomCall();
                if (randomCallId != -1)
                {
                    queuedTimerMessages.Add("Request");

                    await Task.Run(() =>
                    {
                        AddRequest(Task.CurrentId, randomCallId, Operation.UpdateState);
                    });

                    //AddRequest(Task.CurrentId, randomCallId, Operation.UpdateState);
                }
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void HandleTimerUiUpdate(object sender, EventArgs e)
        {
            try
            {
                //DoUiUpdate();
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }
        #endregion

        private void DoUiUpdate()
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    //UpdateIndicator(lblRequest, false);
                    UpdateLabels();
                    BindStateDataToGrid();
                    BindRequestDataToGrid();
                    LogTimerMessages();
                    LogCallMessages();
                    LogRequestMessages();
                }));
            }    

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void CleanupQueueAndProcesses()
        {
            try
            {
                //lock (Requests)
                if (Requests != null)
                {
                    lock (Requests)
                    {
                        while (Requests.Any())
                        {
                            ProcessNextRequest();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void StartProcessing()
        {
            try
            { 
                _timerAddCallToState.Start();
                _timerDeleteCallFromState.Start();
                _timerAddRequest.Start();
                _timerProcessRequest.Start();
                _timerUiUpdate.Start();
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }

        }

        private void StopRequests()
        {
            try
            {
                _timerAddCallToState.Stop();
                _timerDeleteCallFromState.Stop();
                _timerAddRequest.Stop();
                _timerProcessRequest.Stop();
                _timerUiUpdate.Stop();

                CleanupQueueAndProcesses();
                DoUiUpdate();
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void AddNewCall(int? requesterId)
        {
            try
            {
                _callCounter++;

                queuedCallMessages.Add($"Adding a new call, requester: {requesterId}, total: {_callCounter}");
                //lock (State)
                {
                    State.Add(_callCounter, new Call()
                    {
                        Id = _callCounter,
                        State = UI.State.None,
                        Description = $"New Call Added, Call Id: {_callCounter}"
                    });
                }
            }

            catch (Exception ex)
            {
                queuedCallMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private int GetRandomCall()
        {
            try
            {
                var callId = -1;
                //lock (State)
                {
                    if (_callCounter > 0 && State.Any())
                    {
                        var callIndex = State.Count == 1 ? 0 : _randomGenerator.Next(1, State.Count - 1);
                        //find a random call from 1 - seedCallCount
                        var callObject = State.Values.ElementAt(callIndex);
                        if (callObject != null)
                        {
                            //var callToDelete = _randomGenerator.Next(1, _callCounter);

                            //add an delete request
                            //_requestCounter++;
                            //var requestId = _requestCounter;
                            callId = callObject.Id;

                            return callId;
                        }
                    }
                }

                return callId;
            }

            catch(Exception ex)
            {
                queuedCallMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
                return -1;
            }
        }

        private void DeleteCall(int? requesterId)
        {
            try
            {
                var callToDelete = GetRandomCall();
                if (callToDelete != -1)
                {
                    _totalCallsDeleted++;
                    queuedCallMessages.Add($"Deleting a call, requester: {requesterId}, total: {_callCounter}");

                    //lock (State)
                    {
                        if (State.Any(s => s.Value.Id == callToDelete))
                        {
                            var stateObject = State.FirstOrDefault(s => s.Value.Id == callToDelete);
                            var key = stateObject.Key;
                            State.Remove(key);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                queuedCallMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void AddRequest(int? requesterId, int? callId, Operation operation = Operation.UpdateState)
        {
            try
            {
                _requestCounter++;

                queuedRequestMessages.Add($"Adding Request, request Id: {_requestCounter}, requester Id: {requesterId?.ToString() ?? ""}");
                var request = new Request()
                {
                    RequestId = _requestCounter,
                    CallId = callId,
                    Requester = requesterId,
                    Operation = operation,
                    Start = DateTime.Now
                };

                lock (Requests)
                {
                    Requests.Enqueue(request);
                }
            }


            catch (Exception ex)
            {
                queuedRequestMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void ProcessNextRequest()
        {
            try
            {
                Request request = null;
                lock (Requests)
                {
                    if (Requests.Any())
                    {
                        request = Requests.Dequeue();
                    }
                }

                if (request == null)
                {
                    queuedRequestMessages.Add("Nothing to process, queue is empty");
                }
                else
                {
                    queuedRequestMessages.Add($"Processing next item from queue: {request.RequestId}");

                    switch (request.Operation)
                    {
                        case Operation.UpdateState:
                            //Generate a random State between 1 and 4
                            var newState = (State) _randomGenerator.Next(1, 4);

                            //lock (State)
                            {
                                if (State.Any(s => s.Value.Id == request.CallId))
                                    State.FirstOrDefault(s => s.Value.Id == request.CallId).Value.State = newState;
                            }
                            break;

                        case Operation.AddCall:
                            AddNewCall(request.Requester);
                            break;

                        case Operation.DeleteCall:
                            DeleteCall(request.RequestId);

                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }


                if (_stopRequested)
                    _timerProcessRequest.Stop();
                
            }

            catch (Exception ex)
            {
                queuedRequestMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }


        private void AddItemsToState()
        {
            try
            {
                //LogCallMessage($"Adding {SeedCallCount} Calls");

                for (var i = 1; i <= SeedCallCount; i++)
                {
                    //State.Add(i, new Call()
                    //{
                    //    Id = i, State = UI.State.None, Description = $"New Item Added: {i}"
                    //});
                    var t = Thread.CurrentThread.ManagedThreadId;
                    //AddNewCall(t);
                    AddRequest(t, null, Operation.AddCall);
                }
                _callCounter = State.Count;
            }

            catch (Exception ex)
            {
                queuedCallMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            try
            {
                AddItemsToState();
                SetupTimers();
                //Show data
                //BindStateDataToGrid();
                //UpdateLabels();
            }

            catch (Exception ex)
            {
                queuedCallMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void BindStateDataToGrid()
        {
            try
            {
                dgState.DataSource = null;
                dgState.DataSource = State.Values.ToList();
                dgState.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }

            catch (Exception ex)
            {
                queuedCallMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void BindRequestDataToGrid()
        {
            try
            {
                dgRequests.DataSource = null;
                dgRequests.DataSource = Requests.ToList();
                dgRequests.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }

            catch (Exception ex)
            {
                queuedRequestMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void LogTimerMessages()
        {
            try
            {
                foreach (var message in queuedTimerMessages)
                {
                    txtTimerEvents.Text += $"{message}\r\n";
                }

                queuedTimerMessages.Clear();

                txtTimerEvents.SelectionStart = txtTimerEvents.TextLength;
                txtTimerEvents.ScrollToCaret();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogCallMessages()
        {
            try
            {
                foreach (var message in queuedCallMessages)
                {
                    txtCalls.Text += $"{message}\r\n";
                }
                queuedCallMessages.Clear();

                txtCalls.SelectionStart = txtCalls.TextLength;
                txtCalls.ScrollToCaret();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogRequestMessages()
        {
            try
            {
                foreach (var message in queuedRequestMessages)
                {
                    txtRequests.Text += $"{message}\r\n";
                }
                queuedRequestMessages.Clear();

                txtRequests.SelectionStart = txtRequests.TextLength;
                txtRequests.ScrollToCaret();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateLabels()
        {
            try
            {
                lblTotalCalls.Text = $"Calls: {State.Count}, Added: {_callCounter}, Deleted: {_totalCallsDeleted}";
                lblTotalRequests.Text = $"Pending Requests: {Requests.Count}, Total: {_requestCounter++}";
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void UpdateIndicator(Label lbl, bool isEnbaled)
        {
            try
            {
                //lbl.Invoke(new Action(() =>
                //{
                //    lbl.Enabled = isEnbaled;
                //}));
            }
            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }


        private void btnStartProcessing_Click(object sender, EventArgs e)
        {
            try
            {
                queuedTimerMessages.Add("Processing Started");
                SetupTimers();
                _stopRequested = false;
                //btnClose.Enabled = false;
                StartProcessing();
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void btnStopProcessing_Click(object sender, EventArgs e)
        {
            try
            {
                queuedTimerMessages.Add("Finishing processing, cleaning up queue...");

                _stopRequested = true;
                StopRequests();

                //btnClose.Enabled = true;
                //LogMessage("Processing completed");
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                _stopRequested = true;
                Close();
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _stopRequested = true;
                StopRequests();
            }

            catch (Exception ex)
            {
                queuedTimerMessages.Add($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void lblTotalRequests_Click(object sender, EventArgs e)
        {
        }

        private void dgRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
