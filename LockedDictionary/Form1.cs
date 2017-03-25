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
        private const int AddCallInterval = 5000;
        private const int RemoveCallInterval = 10000;
        private const int AddRequestInterval = 1000;
        private const int ProcessRequestInterval = 500;
        private int _totalCallsAdded = 0;
        private int _totalCallsDeleted = 0;


        public readonly Dictionary<int, Call> State = new Dictionary<int, Call>();
        public readonly Queue<Request> Requests = new Queue<Request>();
        private readonly Random _randomGenerator = new Random();

        #region Timers
        //Timer to add calls to state
        private Timer _timerAddCallToState;

        //Timer to remove calls from state
        private Timer _timerRemoveCallFromState;

        //Timer to add requests
        private Timer _timerAddRequest;

        //Timer to process requests
        private Timer _timerProcessRequest;
        #endregion

        private void SetupTimers()
        {
            _timerAddCallToState = new Timer {Interval = AddCallInterval }; // add new call every 30 seconds
            _timerAddCallToState.Tick += HandleTimerAddCall;

            _timerRemoveCallFromState = new Timer {Interval = RemoveCallInterval }; // delete a call 60 seconds
            _timerRemoveCallFromState.Tick += HandleTimerRemoveCall;

            _timerAddRequest = new Timer {Interval = AddRequestInterval }; //add new request every 500 milliseconds
            _timerAddRequest.Tick += HandleTimerAddRequest;

            _timerProcessRequest = new Timer {Interval = ProcessRequestInterval };  //process a request every 1 second
            _timerProcessRequest.Tick += HandleTimerProcessRequest;
        }

        #region Timer Handlers
        private async void HandleTimerAddCall(object sender, EventArgs e)
        {
            try
            {
                LogTimerMessage("Add");
                UpdateIndicator(lblAddCall, true);
                await Task.Run(() =>
                {
                    //AddNewCall(Task.CurrentId);
                    AddRequest(Task.CurrentId, null, Operation.AddCall);
                });
                UpdateIndicator(lblAddCall, false);
            }

            catch (Exception ex)
            {
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private async void HandleTimerRemoveCall(object sender, EventArgs e)
        {
            try
            {
                LogTimerMessage("Remove");
                UpdateIndicator(lblDeleteCall, true);
                await Task.Run(() =>
                {
                    RemoveCall(Task.CurrentId);
                });
                UpdateIndicator(lblDeleteCall, false);
            }

            catch (Exception ex)
            {
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private async void HandleTimerProcessRequest(object sender, EventArgs e)
        {
            try
            {
                LogTimerMessage("Process");
                UpdateIndicator(lblProcessIndicator, true);
                await Task.Run(() =>
                {
                    ProcessNextRequest();
                });

                UpdateIndicator(lblProcessIndicator, false);

                //lock (Requests)
                //{
                //    if (Requests.Any() == false && _stopRequested)
                //    {
                //        btnClose.Invoke(new Action(() => { btnClose.Enabled = true; }));
                //        _timerProcessRequest.Stop();
                //    }
                //    else
                //        btnClose.Invoke(new Action(() => { btnClose.Enabled = false; }));
                //}
            }

            catch (Exception ex)
            {
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private async void HandleTimerAddRequest(object sender, EventArgs e)
        {
            try
            {
                LogTimerMessage("Request");
                UpdateIndicator(lblRequest, true);
                if (State != null && State.Any())
                {
                    _requestCounter++;
                    //var requestId = randomGenerator.Next();
                    var requestId = _requestCounter;
                    var callIndex = State.Count == 1 ? 0 : _randomGenerator.Next(1, State.Count - 1);
                    //find a random call from 1 - seedCallCount
                    var callObject = State.Values.ElementAt(callIndex);
                    if (callObject != null)
                    {
                        await Task.Run(() =>
                        {
                            AddRequest(Task.CurrentId, callObject.Id, Operation.UpdateState);
                        });
                    }
                }
                UpdateIndicator(lblRequest, false);
            }

            catch (Exception ex)
            {
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }
        #endregion

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
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void StartProcessing()
        {
            try
            { 
                _timerAddCallToState.Start();
                _timerRemoveCallFromState.Start();
                _timerAddRequest.Start();
                _timerProcessRequest.Start();
            }

            catch (Exception ex)
            {
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }

        }

        private void StopRequests()
        {
            try
            {
                _timerAddCallToState.Stop();
                _timerRemoveCallFromState.Stop();
                _timerAddRequest.Stop();
                _timerProcessRequest.Stop();

                CleanupQueueAndProcesses();

                //lock (Requests)
                //{
                //    if (!Requests.Any())
                //        _timerProcessRequest.Stop();
                //}
            }

            catch (Exception ex)
            {
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void AddNewCall(int? requesterId)
        {
            try
            {
                _totalCallsAdded++;
                //var requestId = randomGenerator.Next();
                var requestId = _requestCounter;
                //var callId = callToDelete;
                //AddRequest(requesterId, null, Operation.AddCall);


                _callCounter++;
                LogCallMessage($"Adding a new call, requester: {requesterId}, total: {_callCounter}");
                State.Add(_callCounter, new Call()
                {
                    Id = _callCounter,
                    State = UI.State.None,
                    Description = $"New Item Added: {_callCounter}"
                });

                //AddRequest(requesterId, null, Operation.AddCall);
            }

            catch (Exception ex)
            {
                LogCallMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void RemoveCall(int? requesterId)
        {
            try
            {
                //delete random call
                if (_callCounter > 0 && State.Any())
                {
                    _totalCallsDeleted++;



                    var callIndex = State.Count == 1 ? 0 : _randomGenerator.Next(1, State.Count - 1);
                    //find a random call from 1 - seedCallCount
                    var callObject = State.Values.ElementAt(callIndex);
                    if (callObject != null)
                    {
                        var callToDelete = _randomGenerator.Next(1, _callCounter);
                        LogCallMessage($"Deleting call: {callObject.Id}");

                        //add an delete request
                        _requestCounter++;
                        var requestId = _requestCounter;
                        var callId = callObject.Id;
                        AddRequest(requesterId, callId, Operation.DeleteCall);
                    }
                }
            }

            catch (Exception ex)
            {
                LogCallMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void AddRequest(int? requesterId, int? callId, Operation operation = Operation.UpdateState)
        {
            try
            {
                _requestCounter++;

                LogRequestMessage($"Adding Request, request Id: {_requestCounter}, requester Id: {requesterId?.ToString() ?? ""}");
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

                UpdateUi();
                BindRequestDataToGrid();
            }


            catch (Exception ex)
            {
                LogRequestMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void ProcessNextRequest()
        {
            try
            {
                //LogMessage($"Processing next item from queue");

                lock (Requests)
                {
                    if (Requests.Any())
                    {
                        var request = Requests.Dequeue();
                        LogRequestMessage($"Processing next item from queue: {request.RequestId}");

                        //Now do something with the state

                        //For UpdateState do a random state change, for delete remove the call
                        switch (request.Operation)
                        {
                            case Operation.UpdateState:
                                //Generate a random State between 1 and 4
                                var newState = (State)_randomGenerator.Next(1, 4);

                                if (State.Any(s => s.Value.Id == request.CallId))
                                    State.FirstOrDefault(s => s.Value.Id == request.CallId).Value.State = newState;
                                break;

                            case Operation.AddCall:
                                AddNewCall(request.Requester);
                                break;

                            case Operation.DeleteCall:
                                if (State.Any(s => s.Value.Id == request.CallId))
                                { 
                                    var stateObject = State.FirstOrDefault(s => s.Value.Id == request.CallId);
                                    var key = stateObject.Key;
                                    State.Remove(key);
                                }

                                break;

                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        //if (request.Operation == Operation.UpdateState)
                        //{

                        //}
                        //else
                        //{
                        //    if (request.Operation == Operation.DeleteCall)
                        //    {
                        //    }
                        //}
                    }
                    else
                    {
                        LogRequestMessage("Nothing to process, queue is empty");
                    }

                    if (_stopRequested && !Requests.Any())
                        _timerProcessRequest.Stop();
                }


                UpdateUi();
                BindStateDataToGrid();
                BindRequestDataToGrid();
            }

            catch (Exception ex)
            {
                LogRequestMessage($"{ex.Message}\r\n{ex.StackTrace}");
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
                LogCallMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            try
            {
                AddItemsToState();
                SetupTimers();
                //Show data
                BindStateDataToGrid();
                UpdateUi();
            }

            catch (Exception ex)
            {
                LogCallMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void BindStateDataToGrid()
        {
            try
            {
                dgRequests.Invoke(new Action(() =>
                {
                    dgState.DataSource = null;
                    dgState.DataSource = State.Values.ToList();
                    dgState.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }));
            }

            catch (Exception ex)
            {
                LogCallMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void BindRequestDataToGrid()
        {
            try
            {
                //lock (Requests)
                {
                    //if (Requests != null && Requests.Any())
                    {
                        dgRequests.Invoke(new Action(() =>
                        {
                            lock (Requests)
                            {
                                if (Requests != null && Requests.Any())
                                {
                                    dgRequests.DataSource = null;
                                    dgRequests.DataSource = Requests.ToList();
                                    dgRequests.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                                }
                            }


                        }));
                    }
                }
            }

            catch (Exception ex)
            {
                LogRequestMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void LogTimerMessage(string text)
        {
            try
            {
                txtTimerEvents.Invoke(new Action(() =>
                {
                    Status.Text = text;
                    txtTimerEvents.Text += $"{text}\r\n";
                    txtTimerEvents.SelectionStart = txtTimerEvents.TextLength;
                    txtTimerEvents.ScrollToCaret();
                }));
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogCallMessage(string text)
        {
            try
            {
                txtCalls.Invoke(new Action(() =>
                {
                    Status.Text = text;
                    txtCalls.Text += $"{text}\r\n";
                    txtCalls.SelectionStart = txtCalls.TextLength;
                    txtCalls.ScrollToCaret();
                }));
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogRequestMessage(string text)
        {
            try
            {
                txtRequests.Invoke(new Action(() =>
                {
                    Status.Text = text;
                    txtRequests.Text += $"{text}\r\n";
                    txtRequests.SelectionStart = txtRequests.TextLength;
                    txtRequests.ScrollToCaret();
                }));
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateUi()
        {
            try
            {
                //button states
                //btnStartProcessing.Invoke(new Action(() => { btnStartProcessing.Enabled = Requests.Count > 0; }));
                //btnStopProcessing.Invoke(new Action(() => { btnStopProcessing.Enabled = Requests.Count > 0; }));
                //btnClose.Invoke(new Action(() => { btnClose.Enabled = Requests.Count > 0 && _stopRequested; }));

                //totals
                btnStartProcessing.Invoke(new Action(() =>
                {
                    lblTotalCalls.Visible = State.Count > 0;
                    lblTotalCalls.Text = $"Calls: {State.Count}, Added: {_totalCallsAdded}, Removed: {_totalCallsDeleted}";
                    //lblTotalCalls.Text = $"Calls: {State.Count}";
                }));

                btnStartProcessing.Invoke(new Action(() =>
                {
                    lblTotalRequests.Visible = Requests.Count > 0;
                    lblTotalRequests.Text = $"Requests: {Requests.Count}";
                }));
            }

            catch (Exception ex)
            {
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void UpdateIndicator(Label lbl, bool isEnbaled)
        {
            try
            {
                lbl.Invoke(new Action(() =>
                {
                    lbl.Enabled = isEnbaled;
                }));
            }
            catch (Exception ex)
            {
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }


        private void btnStartProcessing_Click(object sender, EventArgs e)
        {
            try
            {
                LogTimerMessage("Processing Started");
                SetupTimers();
                _stopRequested = false;
                //btnClose.Enabled = false;
                StartProcessing();
            }

            catch (Exception ex)
            {
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void btnStopProcessing_Click(object sender, EventArgs e)
        {
            try
            {
                LogTimerMessage("Finishing processing, cleaning up queue...");

                _stopRequested = true;
                StopRequests();

                //btnClose.Enabled = true;
                //LogMessage("Processing completed");
            }

            catch (Exception ex)
            {
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
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
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
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
                LogTimerMessage($"{ex.Message}\r\n{ex.StackTrace}");
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
