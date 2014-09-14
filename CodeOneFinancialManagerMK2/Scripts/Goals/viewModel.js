var goalViewModel = {
    newGoalVisible: ko.observable(false),
    goalDescription: ko.observable(""),
    goalAmount: ko.observable(0),
    goalDate: ko.observable(""),
    newGoalClicked: function () {
        $('#modal-1').prop('checked', true);
    },
    addGoal: function () {
        $('#modal-1').prop('checked', false);
        //Save goal here
    }
};

ko.applyBindings(goalViewModel, $(".body-container")[0]);
