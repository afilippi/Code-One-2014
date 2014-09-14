var goalViewModel = {
    newGoalVisible: ko.observable(false),
    goalDescription: ko.observable(""),
    goalAmount: ko.observable(0),
    goalDate: ko.observable(""),
    tempgoalDescription: ko.observable("A Disney Vacation"),
    tempgoalAmount: ko.observable("$2,000"),
    tempgoalSaved: ko.observable("$1,700"),
    tempDate: ko.observable("11/2/2014"),
    tempEstimate: ko.observable("10/1/2014"),
    newGoalClicked: function () {
        $('#modal-1').prop('checked', true);
    },
    addGoal: function () {
        $('#modal-1').prop('checked', false);
        //Save goal here
    }
};

ko.applyBindings(goalViewModel, $(".body-container")[0]);
