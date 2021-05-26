import "./App.css";
import { Component } from "react";
import Layout from "../../components/Layout/Layout";
import Home from "../../components/Home/Home";
import { Route, Switch } from "react-router";
import { BrowserRouter } from "react-router-dom";
import Series from "../../components/Series/Series";
import PlayersGeneral from "../../components/PlayersGeneral/PlayersGeneral";
import Teams from "../../components/Teams/Teams";
import Games from "../../components/Games/Games";
import DirectorsGeneral from "../../components/DirectorsGeneral/DirectorsGeneral";
import AllStarTeams from "../../components/AllStarTeams/AllStarTeams";
import Team from "../../components/Team/Team";
import Game from "../../components/Game/Game";
import Player from "../../components/Player/Player";
import Serie from "../../components/Serie/Serie";
import TeamInSerie from "../../components/TeamInSerie/TeamInSerie";

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <Layout>
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/series" component={Series} />
            <Route path="/allstarteams" component={AllStarTeams} />
            <Route path="/players_general" component={PlayersGeneral} />
            <Route path="/teams" component={Teams} />
            <Route path="/games" component={Games} />
            <Route path="/directors" component={DirectorsGeneral} />
            <Route path="/team" component={Team} />
            <Route path="/game/id" component={Game} />
            <Route path="/serie" component={Serie} />
            <Route path="/serie_team" component={TeamInSerie} />

            {/* <Route path="/player/id" component={Player} /> */}
          </Switch>
        </Layout>
      </BrowserRouter>
    );
  }
}

export default App;
