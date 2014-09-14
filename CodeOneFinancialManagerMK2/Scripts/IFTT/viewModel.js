jQuery.fn.visible = function () {
    return this.css('visibility', 'visible');
};

jQuery.fn.invisible = function () {
    return this.css('visibility', 'hidden');
};


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
        { id: 1, fullName: 'Jake Jenson' },
        { id: 2, fullName: 'Tommy Jenson' },
        { id: 3, fullName: 'Emily Jenson' }
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

var updateTriggerForSpending = function () {
    $('#trigger-1 .dropdown-label').text('Who\'s Spending?');
    $('#trigger-2 .dropdown-label').text('Spends How Much?');
    $('#trigger-3 .dropdown-label').text('In What Time Period?');
    $('#trigger-4 .dropdown-label').text('What Category?');
    $('#trigger-2-textfield').show();
    $('#trigger-2 .selectricWrapper').hide();
    $('#trigger-1').visible();
    $('#trigger-2').visible();
    $('#trigger-3').visible();
    $('#trigger-4').visible();
};

var updateTriggerForWithdraw = function () {
    $('#trigger-1 .dropdown-label').text('Who\'s Withdrawing?');
    $('#trigger-2 .dropdown-label').text('Withdrawl Amount');
    $('#trigger-2-textfield').show();
    $('#trigger-2 .selectricWrapper').hide();
    $('#trigger-1').visible();
    $('#trigger-2').visible();
    $('#trigger-3').invisible();
    $('#trigger-4').invisible();
};

var updateTriggerForDeposit = function () {
    $('#trigger-1 .dropdown-label').text('Who\'s Depositing?');
    $('#trigger-2 .dropdown-label').text('Amount of Deposit');
    $('#trigger-2-textfield').show();
    $('#trigger-2 .selectricWrapper').hide();
    $('#trigger-1').visible();
    $('#trigger-2').visible();
    $('#trigger-3').invisible();
    $('#trigger-4').invisible();
};

var updateTriggerForGoal = function () {
    $('#trigger-1 .dropdown-label').text('Who\'s Goal?');
    $('#trigger-2 .dropdown-label').text('Which Goal?');
    $('#trigger-2-textfield').hide();
    $('#trigger-2 .selectricWrapper').show();
    $('#trigger-1').visible();
    $('#trigger-2').visible();
    $('#trigger-3').invisible();
    $('#trigger-4').invisible();
};

var updateTriggerForEmpty = function () {
    $('#trigger-1').invisible();
    $('#trigger-2').invisible();
    $('#trigger-3').invisible();
    $('#trigger-4').invisible();
};

var updateActionForEmail = function () {
    $('#action-1 .dropdown-label').text('Email Address');
    $('#action-1-contactinfo').show();
    $('#action-1-amount').hide();
    $('#action-2 .dropdown-label').text('N/A - Remove');
    $('#action-1').visible();
    $('#action-2').invisible();
};

var updateActionForText = function () {
    $('#action-1 .dropdown-label').text('Phone Number');
    $('#action-1-contactinfo').show();
    $('#action-1-amount').hide();
    $('#action-1').visible();
    $('#action-2').invisible();
};

var updateActionForCall = function () {
    $('#action-1 .dropdown-label').text('Phone Number');
    $('#action-1-contactinfo').show();
    $('#action-1-amount').hide();
    $('#action-1').visible();
    $('#action-2').invisible();
};

var updateActionForAlert = function () {
    $('#action-1').invisible();
    $('#action-2').invisible();
    $('#action-1-contactinfo').hide();
    $('#action-1-amount').hide();
};

var updateActionForTransfer = function () {
    $('#action-1 .dropdown-label').text('Transfer Amount');
    $('#action-2 .dropdown-label').text('Destination Account');
    $('#action-1-contactinfo').hide();
    $('#action-1-amount').show();
    $('#action-1').visible();
    $('#action-2').visible();
};

var updateActionForEmpty = function () {
    $('#action-1-contactinfo').hide();
    $('#action-1-amount').hide();
    $('#action-1').invisible();
    $('#action-2').invisible();
};

IFTTViewModel.selectedTrigger.subscribe(function (newTrigger) {
    var triggerId = newTrigger ? newTrigger.id : undefined;

    switch (triggerId) {
        case 1:
            updateTriggerForSpending();
            break;
        case 2:
            updateTriggerForWithdraw();
            break;
        case 3:
            updateTriggerForDeposit();
            break;
        case 4:
            updateTriggerForGoal();
            break;
        default:
            updateTriggerForEmpty();
            break;
    }
});

IFTTViewModel.selectedAction.subscribe(function (newAction) {
    var actionId = newAction ? newAction.id : undefined;

    switch (actionId) {
        case 1:
            updateActionForEmail();
            break;
        case 2:
            updateActionForText();
            break;
        case 3:
            updateActionForCall();
            break;
        case 4:
            updateActionForAlert();
            break;
        case 5:
            updateActionForTransfer();
            break;
        default:
            updateActionForEmpty();
            break;
    }
});


function ShowActionPlans(result) {
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

ko.applyBindings(IFTTViewModel, $(".body-container")[0]);
