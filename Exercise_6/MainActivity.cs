using System;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise_6.Adapters;
using Exercise_6.Models;

namespace Exercise_6
{
    [Activity(Label = "Exercise_6", MainLauncher = true)]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.recyclerView)] private RecyclerView recyclerView;

        private List<object> callSmsObjects;

        private CallSmsAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);

            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            recyclerView.HasFixedSize = true;
            Init();
        }

        private void Init()
        {
            callSmsObjects = new List<object>
            {
                new Call
                {
                    Caller = "Man",
                    PhoneNumber = "0966156153",
                    TimeReceived = new DateTime(2018, 1, 12, 21, 10, 00)
                },
                new Sms
                {
                    Sender = "Thuan",
                    PhoneNumber = "09696969069",
                    Content = "Đi chơi với mình không?",
                    TimeReceived = new DateTime(2018, 1, 12, 10, 00, 00)
                },
                new Call
                {
                    Caller = "Man",
                    PhoneNumber = "0966156153",
                    TimeReceived = new DateTime(2018, 1, 12, 21, 10, 00)
                },
                new Sms
                {
                    Sender = "Thuan",
                    PhoneNumber = "09696969069",
                    Content = "Đi chơi với mình không?",
                    TimeReceived = new DateTime(2018, 1, 12, 10, 00, 00)
                },
                new Call
                {
                    Caller = "Man",
                    PhoneNumber = "0966156153",
                    TimeReceived = new DateTime(2018, 1, 12, 21, 10, 00)
                },
                new Sms
                {
                    Sender = "Thuan",
                    PhoneNumber = "09696969069",
                    Content = "Đi chơi với mình không?",
                    TimeReceived = new DateTime(2018, 1, 12, 10, 00, 00)
                },
                new Call
                {
                    Caller = "Man",
                    PhoneNumber = "0966156153",
                    TimeReceived = new DateTime(2018, 1, 12, 21, 10, 00)
                },
                new Sms
                {
                    Sender = "Thuan",
                    PhoneNumber = "09696969069",
                    Content = "Đi chơi với mình không?",
                    TimeReceived = new DateTime(2018, 1, 12, 10, 00, 00)
                },
                new Sms
                {
                    Sender = "Thuan",
                    PhoneNumber = "09696969069",
                    Content = "Đi chơi với mình không?",
                    TimeReceived = new DateTime(2018, 1, 12, 10, 00, 00)
                },
                new Call
                {
                    Caller = "Man",
                    PhoneNumber = "0966156153",
                    TimeReceived = new DateTime(2018, 1, 12, 21, 10, 00)
                },
                new Sms
                {
                    Sender = "Thuan",
                    PhoneNumber = "09696969069",
                    Content = "Đi chơi với mình không?",
                    TimeReceived = new DateTime(2018, 1, 12, 10, 00, 00)
                },
                new Call
                {
                    Caller = "Man",
                    PhoneNumber = "0966156153",
                    TimeReceived = new DateTime(2018, 1, 12, 21, 10, 00)
                },
                new Sms
                {
                    Sender = "Thuan",
                    PhoneNumber = "09696969069",
                    Content = "Đi chơi với mình không?",
                    TimeReceived = new DateTime(2018, 1, 12, 10, 00, 00)
                },
                new Sms
                {
                    Sender = "Thuan",
                    PhoneNumber = "09696969069",
                    Content = "Đi chơi với mình không?",
                    TimeReceived = new DateTime(2018, 1, 12, 10, 00, 00)
                },
                new Call
                {
                    Caller = "Man",
                    PhoneNumber = "0966156153",
                    TimeReceived = new DateTime(2018, 1, 12, 21, 10, 00)
                },
                new Sms
                {
                    Sender = "Thuan",
                    PhoneNumber = "09696969069",
                    Content = "Đi chơi với mình không?",
                    TimeReceived = new DateTime(2018, 1, 12, 10, 00, 00)
                },
                new Call
                {
                    Caller = "Man",
                    PhoneNumber = "0966156153",
                    TimeReceived = new DateTime(2018, 1, 12, 21, 10, 00)
                },
                new Sms
                {
                    Sender = "Thuan",
                    PhoneNumber = "09696969069",
                    Content = "Đi chơi với mình không?",
                    TimeReceived = new DateTime(2018, 1, 12, 10, 00, 00)
                }
            };

            adapter = new CallSmsAdapter(callSmsObjects);
            recyclerView.SetAdapter(adapter);
        }
    }
}

