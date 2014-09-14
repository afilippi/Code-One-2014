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
        { id: 1, text: 'A Week' },
        { id: 2, text: 'A Month' }
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
    selectedAccount: ko.observable()

};

var updateTriggerForSpending = function () {
    $('#trigger-1 .dropdown-label').text('Who\'s Spending?');
    $('#trigger-2 .dropdown-label').text('Spends How Much?');
    $('#trigger-3 .dropdown-label').text('In What Time Period?');
    $('#trigger-4 .dropdown-label').text('What Category?');
    $('#trigger-1 .cell-content').show();
    $('#trigger-2 .cell-content').show();
    $('#trigger-3 .cell-content').show();
    $('#trigger-4 .cell-content').show();
};

var updateTriggerForWithdraw = function () {
    $('#trigger-1 .dropdown-label').text('Who\'s Withdrawing?');
    $('#trigger-2 .dropdown-label').text('Withdrawl Amount');
    $('#trigger-1 .cell-content').show();
    $('#trigger-2 .cell-content').show();
    $('#trigger-3 .cell-content').hide();
    $('#trigger-4 .cell-content').hide();
};

var updateTriggerForDeposit = function () {
    $('#trigger-1 .dropdown-label').text('Who\'s Depositing?');
    $('#trigger-2 .dropdown-label').text('Amount of Deposit');
    $('#trigger-1 .cell-content').show();
    $('#trigger-2 .cell-content').show();
    $('#trigger-3 .cell-content').hide();
    $('#trigger-4 .cell-content').hide();
};

var updateTriggerForGoal = function () {
    $('#trigger-1 .dropdown-label').text('Who\'s Goal?');
    $('#trigger-2 .dropdown-label').text('Which Goal?');
    $('#trigger-1 .cell-content').show();
    $('#trigger-2 .cell-content').show();
    $('#trigger-3 .cell-content').hide();
    $('#trigger-4 .cell-content').hide();
};

var updateTriggerForEmpty = function () {
    $('#trigger-1 .cell-content').hide();
    $('#trigger-2 .cell-content').hide();
    $('#trigger-3 .cell-content').hide();
    $('#trigger-4 .cell-content').hide();
};

var updateActionForEmail = function () {
    $('#action-1 .dropdown-label').text('Email Address');
    $('#action-2 .dropdown-label').text('N/A - Remove');
    $('#action-3 .dropdown-label').text('N/A - Remove');
    $('#action-4 .dropdown-label').text('N/A - Remove');
};

var updateActionForText = function () {
    $('#action-1 .dropdown-label').text('Phone Number');
    $('#action-2 .dropdown-label').text('N/A - Remove');
    $('#action-3 .dropdown-label').text('N/A - Remove');
    $('#action-4 .dropdown-label').text('N/A - Remove');
};

var updateActionForCall = function () {
    $('#action-1 .dropdown-label').text('Phone Number');
    $('#action-2 .dropdown-label').text('N/A - Remove');
    $('#action-3 .dropdown-label').text('N/A - Remove');
    $('#action-4 .dropdown-label').text('N/A - Remove');
};

var updateActionForAlert = function () {
    $('#action-1 .dropdown-label').text('N/A - Remove');
    $('#action-2 .dropdown-label').text('N/A - Remove');
    $('#action-3 .dropdown-label').text('N/A - Remove');
    $('#action-4 .dropdown-label').text('N/A - Remove');
};

var updateActionForTransfer = function () {
    $('#action-1 .dropdown-label').text('Transfer Amount');
    $('#action-2 .dropdown-label').text('Destination Account');
    $('#action-3 .dropdown-label').text('N/A - Remove');
    $('#action-4 .dropdown-label').text('N/A - Remove');
};

var updateActionForEmpty = function () {
    $('#action-1 .dropdown-label').text('Who\'s Goal?');
    $('#action-2 .dropdown-label').text('Which Goal?');
    $('#action-3 .dropdown-label').text('N/A - Remove');
    $('#action-4 .dropdown-label').text('N/A - Remove');
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
            console.log('Trigger blank state');
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
            console.log('Action blank state');
            break;
    }
});


IFTTViewModel.selectedAction.subscribe(function (newAction) {

});

ko.applyBindings(IFTTViewModel);
