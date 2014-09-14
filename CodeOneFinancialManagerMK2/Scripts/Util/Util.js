
 function PostGoal() {

    var serviceURL = '/Goal/PostGoal';
    var data = new GoalModel();

    $.ajax({
        type: "POST",
        url: serviceURL,
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: "json",
        success: function (result) { },
        error: function (result) { }
    });
 }


 function GetGoal() {

    var serviceURL = '/Goal/GetGoal';
    var data = new AccountID();

    $.ajax({
        type: "POST",
        url: serviceURL,
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
           
        },
        error: function (result) {
          
        }
    });
 }

 function GetAlerts() {

     var serviceURL = '/Utility/GetAlerts';
     var data = new AccountID();

     $.ajax({
         type: "POST",
         url: serviceURL,
         data: JSON.stringify(data),
         contentType: "application/json",
         dataType: "json",
         success: function (result) {
             
         },
         error: function (result) {
            
         }
     });
 }


 function DemText() {

     var serviceURL = '/Transaction/MakeDemText';
     var data = "";

     $.ajax({
         type: "POST",
         url: serviceURL,
         data: JSON.stringify(data),
         contentType: "application/json",
         dataType: "json",
         success: function (result) { },
         error: function (result) { }
     });
 }


function AccountID() {
    var self = this;
    self.AccountID = 1;
}

function GoalModel() {
    var self = this;
    self.id = 1;
    self.Amount = 40;
    self.Date = new Date();
    self.Description = "something";
    self.SavedAmount = 0;
    self.AccountID = 1;
}
var AlertViewModel = {
    alerts: ko.observableArray([])
};

var serviceURL = '/Utility/GetAlerts';
var data = new AccountID();

$.ajax({
    type: "POST",
    url: serviceURL,
    data: JSON.stringify(data),
    contentType: "application/json",
    dataType: "json",
    success: function (result) {

        AddAlerts(result);

    },
    error: function (result) {
        AddAlerts(result);
    }
});

function AddAlerts(result) {
    
    for (var i = 0; i < result.Alerts.length; i++)
    {
        AlertViewModel.alerts.unshift(result.Alerts[i]);
    }
}


 $(function () {
            // Reference the auto-generated proxy for the hub.
            var chat = $.connection.alertHub;
            
            // Create a function that the hub can call back to display messages.
            chat.client.addNewMessageToPage = function (name, message) {
                //AlertViewModel.alerts.push({Date:name,
                //Description:Message});
                AlertViewModel.alerts.unshift({ Date: name, Description: message });
            };
           
            // Start the connection.
            $.connection.hub.start().done(function () {
              
                });
            });
     
        // This optional function html-encodes messages for display in the page.
        function htmlEncode(value) {
            var encodedValue = $('<div />').text(value).html();
            return encodedValue;
        }





//ko.applyBindings(AlertViewModel, document.getElementById("alertWrapper"));
//      ko.applyBindingsToNode(document.getElementById('alertWrapper'), AlertViewModel);
        $(document).ready(function () {
            ko.applyBindings(AlertViewModel, $("#alertWrapper")[0]);


            document.onkeypress = function (e) {
                e = e || window.event;
                var charCode = (typeof e.which == "number") ? e.which : e.keyCode;
                if (String.fromCharCode(charCode) == "=") {
                    DemText();
                }
            };
        });
