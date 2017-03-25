using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int maxCalls = 10;
        private bool _stopRequested = false;
        private int _requestCounter = 0;
        private Dictionary<int, Call> _state = new Dictionary<int, Call>();
        private Queue<Request> _requests = new Queue<Request>();
        private Random randomGenerator = new Random();

        #region Timers
        //Timer to add calls to state
        private Timer Timer_AddCallToState;

        //Timer to remove calls from state
        private Timer Timer_RemoveCallFromState;

        //Timer to add requests
        private Timer Timer_AddRequest;

        //Timer to process requests
        private Timer Timer_ProcessRequest;
        #endregion

        private void Setup()
        {
            Timer_AddRequest = new Timer();
            Timer_AddRequest.Interval = 500;
            Timer_AddRequest.Tick += HandleTimerAddRequest;

            Timer_ProcessRequest = new Timer();
            Timer_ProcessRequest.Interval = 1000;
            Timer_ProcessRequest.Tick += HandleTimerProcessRequest;
        }

        private async void HandleTimerProcessRequest(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                ProcessNextRequest();
            });
        }

        private async void HandleTimerAddRequest(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                _requestCounter++;
                //var requestId = randomGenerator.Next();
                var requestId = _requestCounter;
                var callId = randomGenerator.Next(1, maxCalls); //find a random call from 1 - maxCalls
                //var callId = 1;
                AddRequest(requestId, callId, Task.CurrentId);
            });
        }

        private void StartProcessing()
        {
            Timer_AddRequest.Start();
            Timer_ProcessRequest.Start();
        }

        private void StopRequests()
        {
            Timer_AddRequest.Stop();

            lock (_requests)
            {
                if (!_requests.Any())
                    Timer_ProcessRequest.Stop();
            }
        }

        //private void StopRequests()
        //{
        //    Timer_AddRequest.Stop();
        //    Timer_ProcessRequest.Stop();
        //}

        private void AddRequest(int requestId, int callId, int? requesterId)
        {
            LogMessage($"Adding Request, request Id: {requestId}, call Id: {callId}, requester Id: {requesterId?.ToString() ?? ""}");
            var request = new Request()
            {
                RequestId = requestId,
                CallId = callId,
                Requester = requesterId,
                Start = DateTime.Now
            };

            lock (_requests)
            {
                _requests.Enqueue(request);
            }

            UpdateUi();
            BindRequestDataToGrid();
        }

        private void ProcessNextRequest()
        {
            //LogMessage($"Processing next item from queue");

            lock (_requests)
            {
                if (_requests.Any())
                {
                    var request = _requests.Dequeue();
                    LogMessage($"Processing next item from queue: {request.RequestId}");

                    //Now do something with the state
                    //Generate a random State between 1 and 4
                    var newState = (State)randomGenerator.Next(1, 4);
                    _state.FirstOrDefault(s => s.Value.Id == request.CallId).Value.State = newState;
                }
                else
                {
                    LogMessage("Nothing to process, queue is empty");
                }

                if (_stopRequested && !_requests.Any())
                    Timer_ProcessRequest.Stop();
            }


            UpdateUi();
            BindStateDataToGrid();
            BindRequestDataToGrid();
        }


        private void AddItemsToState()
        {
            LogMessage($"Adding {maxCalls} Calls");

            for (var i = 1; i <= maxCalls; i++)
            {
                _state.Add(i, new Call()
                {
                    Id = i,
                    State = State.None,
                    Description = $"New Item Added: {i}"
                });
            }
        }

        private async void btnAddItems_Click(object sender, EventArgs e)
        {
            LogMessage("Adding Items...");
            AddItemsToState();

            Setup();

            //Show data
            BindStateDataToGrid();

            ////Generate some requests async
            //AddRequests();

            UpdateUi();
            //btnStartProcessing.Enabled = _state.Count > 0;
            //btnStopProcessing.Enabled = _state.Count > 0 && _requests.Count > 0;
        }

        private void BindStateDataToGrid()
        {
            dgRequests.Invoke(new Action(() =>
            {
                dgState.DataSource = null;
                dgState.DataSource = _state.Values.ToList();
                dgState.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }));
        }

        private void BindRequestDataToGrid()
        {
            dgRequests.Invoke(new Action(() =>
            {
                dgRequests.DataSource = null;
                dgRequests.DataSource = _requests.ToList();
                dgRequests.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }));
        }

        private void LogMessage(string text)
        {
            txtLog.Invoke(new Action(() =>
            {
                Status.Text = text;
                txtLog.Text += $"{text}\r\n";
            }));
        }

        private void UpdateUi()
        {
            //button states
            btnStartProcessing.Invoke(new Action(() =>
            {
                btnStartProcessing.Enabled = _state.Count > 0;
            }));

            btnStopProcessing.Invoke(new Action(() =>
            { 
                btnStopProcessing.Enabled = _state.Count > 0 && _requests.Count > 0;
            }));

            btnClose.Invoke(new Action(() =>
            {
                btnClose.Enabled = _requests.Count > 0 && _stopRequested;
            }));



            //totals
            btnStartProcessing.Invoke(new Action(() =>
            {
                lblTotalCalls.Visible = _state.Count > 0;
                lblTotalCalls.Text = $"Calls: {_state.Count}";
            }));

            btnStartProcessing.Invoke(new Action(() =>
            {
                lblTotalRequests.Visible = _requests.Count > 0;
                lblTotalRequests.Text = $"Requests: {_requests.Count}";
            }));
        }


        private void btnStartProcessing_Click(object sender, EventArgs e)
        {
            _stopRequested = false;
            btnClose.Enabled = false;
            StartProcessing();
        }

        private void btnStopProcessing_Click(object sender, EventArgs e)
        {
            LogMessage("Finishing processing, cleaning up queue...");

            _stopRequested = true;
            StopRequests();

            //btnClose.Enabled = true;
            //LogMessage("Processing completed");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _stopRequested = true;
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _stopRequested = true;
            StopRequests();
        }
    }
}
