const axios = require('./utilities/axios');
const chunk = require('./utilities/chunk');
const config = require('./config');
const accounts = require('./data/accounts/accounts.json');
const url = 'http://localhost:5000';

(async () => {
    let res = await axios.get(`${url}/api/application/status`);

    if (res.success() === true) {
        if (res.data.IsInitialized === false) {
            res = await axios.post(`${url}/api/application/status`, {});
        }
    }

    let chunkedRecords = chunk(accounts, 25);

    for (var chk of chunkedRecords) {
        await Promise.all(chk.map((account) => axios.post(`${url}/api/accounts`, account)));
    }
})();