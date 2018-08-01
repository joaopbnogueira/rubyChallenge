import 'bootstrap';
import * as React from 'react';
import * as ReactDOM from 'react-dom';

import Notes from './react-notes/Notes';

function renderApp() {
    // This code starts up the React app when it runs in a browser. It sets up the routing
    // configuration and injects the app into a DOM element.
    const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href')!;
    ReactDOM.render(
        <Notes />,
        document.getElementById('react-notes-app')
    );
}

renderApp();


