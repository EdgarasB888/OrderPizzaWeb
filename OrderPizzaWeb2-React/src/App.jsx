import React from 'react'
import { BrowserRouter, Switch, Route } from 'react-router-dom'
import { Routes } from './routes'
import Home from "./pages/Home";
import CreatePizza from './pages/CreatePizzaOrder';
import OrdersList from './pages/PizzaOrdersList';


const App = () => {
  return (
    <React.Fragment>
      <BrowserRouter >
        <Switch>
          <Route exact path={Routes.CreatePizza.path} component={CreatePizza} />
          <Route exact path={Routes.Home.path} component={Home} />
          <Route exact path={Routes.OrdersList.path} component={OrdersList} />
        </Switch>
      </BrowserRouter>
    </React.Fragment>
  );

};

export default App;