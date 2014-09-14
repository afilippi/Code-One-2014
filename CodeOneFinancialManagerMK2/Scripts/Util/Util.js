
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
