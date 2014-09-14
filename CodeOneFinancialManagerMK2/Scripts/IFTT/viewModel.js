ko.bindingHandlers.currency = {
    symbol: ko.observable('$'),
    update: function (element, valueAccessor, allBindingsAccessor) {
        return ko.bindingHandlers.text.update(element, function () {
            var value = +(ko.utils.unwrapObservable(valueAccessor()) || 0),
                symbol = ko.utils.unwrapObservable(allBindingsAccessor().symbol === undefined
                            ? allBindingsAccessor().symbol
                            : ko.bindingHandlers.currency.symbol);
            return symbol + value.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1,");
        });
    }
};

var IFTTViewModel = {
    availableTriggers: [
        { id: 1, text: 'OverSpend', displayText: 'Someone spends too much money' },
        { id: 2, text: 'Withdrawal', displayText: 'Someone withdraws money' },
        { id: 3, text: 'Deposit', displayText: 'Someone deposits money' },
        {id: 4, text: 'GoalMet', displayText: 'Someone meets his or her goal'}
        ],
    availableActions: [
        {id: 1, text: 'Email', displayText: 'Send me an email'},
        {id: 2, text: 'Text', displayText: 'Send me a text message'},
        {id: 3, text: 'Call', displayText: 'Call me'},
        {id: 4, text: 'Alert', displayText: 'Show an alert on my dashboard'},
        {id: 5, text: 'Transfer', displayText: 'Transfer money'}
    ],
    availableUsers: [
        { id: 1, fullName: 'Arnold Johnson' },
        { id: 2, fullName: 'Seth Johnson' },
        { id: 3, fullName: 'Emily Johnson' }
    ],
    availableGoals: [
        { id: 1, description: 'Xbox One' },
        { id: 2, description: 'Disneyland' },
        {id: 3, description: 'New Car'}
    ],
    availableTimeFrames: [
        { id: 1, text: 'Once' },
        { id: 2, text: 'Weekly' }
    ],
    availableCategories: [
        {id: 0, text: 'Anywhere'},
        {id: 1, text: 'Restaurants'},
        {id: 2, text: 'Retail'},
        {id: 3, text: 'Travel'}
    ],
    availableAccounts: [
        "Savings",
        "Retirement",
        "Disneyland"
    ],
    selectedTrigger: ko.observable(),
    selectedAction: ko.observable(),
    selectedUser: ko.observable(),
    selectedGoal: ko.observable(),
    selectedTimeFrame: ko.observable(),
    selectedCategory: ko.observable(),
    amount: ko.observable(0),
    email: ko.observable(),
    phone: ko.observable(),
    targetAmount: ko.observable(),
    selectedAccount: ko.observable(),
    createActionPlan: function () {

        var serviceURL = '/Trigger/PostTrigger';
        var data = new ActionPlanModel();

        $.ajax({
            type: "POST",
            url: serviceURL,
            data: JSON.stringify(data),
            contentType: "application/json",
            dataType: "json",
            success: function (result) { },
            error: function (result) { }
        });
    },
    getActionPlans: function () {

        var serviceURL = '/Trigger/GetTrigger';
        var data = new ActionPlanRequest();

        $.ajax({
            type: "POST",
            url: serviceURL,
            data: JSON.stringify(data),
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                ShowActionPlans(result);
            },
            error: function (result) {
                ShowActionPlans(result);
            }
        });


    }
};

function ShowActionPlans(result)
{
    var thing = result;
}

function ActionPlanRequest() {
    var self = this;
    self.AccountID = 1;
}

function ActionPlanModel() {
    var self = this;
    self.id = 1;
    self.AccountID = 1;
    self.ActionID = IFTTViewModel.selectedAction().text;
    self.CurrentAmount = 0;
    self.TriggerAmount = IFTTViewModel.amount();
    self.MCC = IFTTViewModel.selectedCategory().text;
    self.TimeFrame = IFTTViewModel.selectedTimeFrame().text;
    self.Trigger = IFTTViewModel.selectedTrigger().text;
}
ko.applyBindings(IFTTViewModel);
