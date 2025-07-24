import React from 'react';
import ReactDOM from 'react-dom/client';
import Main from "./main"
import { AuthProvider } from './Context/AuthContext';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
   <AuthProvider>
    <Main />
  </AuthProvider>,
);

