const ax = require('axios');

const createConfig = (method, url, data, config) => {
    if (!config) config = {};
    if ('{}' !== JSON.stringify((data || {}))) config['data'] = data;
    config['method'] = method;
    config['url'] = url;

    return config;
};

const formatResponse = (response) => {
    console.log(response);
    if (response.Error) {
        response.status = -1;
        response.statusText = response.code
    }

    if (response.response) response = response.response; // wrapper for error    
    let result = {};

    result['status'] = (response.status || 0);
    result['statusText'] = response.statusText;
    result['success'] = () => {
        return (this['status'] > 200 && this['status'] < 300);
    }
    result['data'] = response.data;

    return result;
}

module.exports.get = (url, config) => this.request(createConfig('get', url, null, config));

module.exports.post = (url, data, config) => this.request(createConfig('post', url, data, config));

module.exports.put = (url, data, config) => this.request(createConfig('put', url, data, config));

module.exports.patch = (url, data, config) => this.request(createConfig('patch', url, data, config));

module.exports.delete = (url, data, config) => this.request(createConfig('delete', url, data, config));

module.exports.request = (config) => new Promise((resolve) => {
    ax(config).then((resp) => {
        resolve(formatResponse(resp));
    }).catch((err) => {
        resolve(formatResponse(err));
    });
});