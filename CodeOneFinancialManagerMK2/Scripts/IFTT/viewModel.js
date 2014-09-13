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
    selectedTrigger: ko.observable(),
    selectedAction: ko.observable(),
    selectedUser: ko.observable(),
    selectedGoal: ko.observable(),
    selectedTimeFrame: ko.observable(),
    selectedCategory: ko.observable(),
    amount: ko.observable(0)

};
ko.applyBindings(IFTTViewModel);
