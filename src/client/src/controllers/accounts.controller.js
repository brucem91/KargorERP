import React from 'react';
import ControllerComponent from '../components/common/Controller';

import Index from '../components/accounts/index';
import Create from '../components/accounts/create';
import View from '../components/accounts/view';

const routes = [
    { path: '/accounts', component: Index },
    { path: '/accounts/create', component: Create },
    { path: '/accounts/view', component: View }
];

export default () => <ControllerComponent routes={routes} />