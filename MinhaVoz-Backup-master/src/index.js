import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from "react-router-dom";

import Login from './paginas/Login/Login';
import PainelAdm from './paginas/PainelAdm/PainelAdm';

import {usuarioAutenticado} from "./servicos/auth";
// import {parseJwt} from './servicos/auth';

const PermissaoAdmin = ({ component: Component }) => (
    <Route
      render={props =>
        usuarioAutenticado() === true ? (
          <Component {...props} />
        ) : (
          <Redirect to={{ pathname: "/painel" }} />
        )
      }
    />
);

const routing = (
    <Router>
        <div>
            <Switch>
                <Route exact path="/" component={Login}/>
                {/* <Route path="/login" component={Login} /> */}
                <PermissaoAdmin path="/painel" component={PainelAdm}/>
            </Switch>
        </div>
    </Router>
);

ReactDOM.render(routing, document.getElementById('root'));