var token = window.token;

let table = new DataTable('#userAccounts', {

    ajax: {
        url: "https://localhost:7295/api/Account/GetUserAccounts",
        dataSrc = "data"
        headers: {"Authorization": "Bearer " + token}
    },
    columns: [
        { data: 'accountNumber', title: 'AccountNumber' },
        { data: 'alias', title: 'Alias' },
        { data: 'accountType', title: 'AccountType' },
        { data: 'currency', title: 'Currency' },
        { data: 'balance', title: 'Balance' },
        { data: 'cbu', title: 'CBU' },
        { data: 'uuid', title: 'UUID'},
    ]
})