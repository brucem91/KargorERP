import qs from 'query-string';

export default () => {
    let search = window.location.hash.split('?')[1] || ''
    return qs.parse(search, { ignoreQueryPrefix: true });
};