var availableAccounts = [
        { id: 1, accountName: 'Savings' },
        { id: 2, accountName: 'IRA' },
        { id: 3, accountName: 'Checking' }
];

var AnalysisViewModel = {
    availableAccounts: availableAccounts,
    selectedAccount: ko.observable(availableAccounts[0])


};
ko.applyBindings(AnalysisViewModel);
