import "./App.css";
import { Component } from "react";
import Layout from "../../components/Layout/Layout";
import Home from "../../components/Home/Home";
import { Route, Switch } from "react-router";
import { BrowserRouter } from "react-router-dom";
import Series from "../../components/Series/Series";
import Players from "../../components/Players/Players";
import Teams from "../../components/Teams/Teams";
import Games from "../../components/Games/Games";
import Directors from "../../components/Directors/Directors";
import AllStarTeams from "../../components/AllStarTeams/AllStarTeams";
import Team from "../../components/Team/Team";
import Game from "../../components/Game/Game";
import Player from "../../components/Player/Player";

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <Layout>
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/series" component={Series} />
            <Route path="/allstarteams" component={AllStarTeams} />
            <Route path="/players" component={Players} />
            <Route path="/teams" component={Teams} />
            <Route path="/games" component={Games} />
            <Route path="/directors" component={Directors} />
            <Route path="/team/id" component={Team} />
            <Route path="/game/id" component={Game} />

            {/* <Route path="/player/id" component={Player} /> */}
          </Switch>
        </Layout>
      </BrowserRouter>
    );
  }
}

export default App;
