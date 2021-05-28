import React, { Component } from "react";
import { Container, Button, Table } from "react-bootstrap";
import { ToolkitProvider } from "react-bootstrap-table2-toolkit";
import "./Series.css";
import "../../containers/App/App.css";
import DeleteEdit from "../../components/DeleteEdit/DeleteEdit";
import Add from "../../components/Add/Add";
import filterFactory, {
  textFilter,
  numberFilter,
  Comparator,
} from "react-bootstrap-table2-filter";
// import { BootstrapTable } from "react-bootstrap-table-next";
// import ReactDataTable from "react-datatable-with-bootstrap";

class Series extends Component {
  state = {
    redirect: null,
    series: [
      {
        id: 1,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        seasonStart: "1994",
        seasonEnd: "1995",
        ng: "50",
        nt: "15",
        winner: "Industriales",
        loser: "Isla de la Juventud",
      },
      {
        id: 2,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        seasonStart: "1996",
        seasonEnd: "1997",
        ng: "40",
        nt: "15",
        winner: "Matanzas",
        loser: "Las Tunas",
      },
      {
        id: 3,
        name: "Serie Nacional de Béisbol",
        reach: "Nacional",
        seasonStart: "1997",
        seasonEnd: "1998",
        ng: "30",
        nt: "15",
        winner: "Industriales",
        loser: "Guantánamo",
      },
    ],
  };
  handleOnClick = (id, name) => {
    // this.setState({ redirect: "/serie" });
    // fetch serie data from data base
    this.props.history.push({
      pathname: "/serie",
      state: {
        serie: {
          id: id,
          name: name,
          standings: [
            {
              place: 1,
              team: {
                id: 1,
                img: "http://localhost:8000/src/logos/industriales.png",
                name: "Industriales",
              },
              won_games: 30,
              lost_games: 10,
            },
            {
              place: 2,
              team: {
                id: 2,
                img: "http://localhost:8000/src/logos/cienfuegos.png",
                name: "Cienfuegos",
              },
              won_games: 27,
              lost_games: 8,
            },
            {
              place: 3,
              team: {
                id: 3,
                img: "http://localhost:8000/src/logos/ciego.png",
                name: "Ciego de Ávila",
              },
              won_games: 24,
              lost_games: 10,
            },
          ],
          allstarteams: [
            {
              id: 1,
              name: "Alexander Malleta",
              img: "http://localhost:8000/src/logos/malleta.jpg",
              position: "Primera Base",
            },
            {
              id: 2,
              name: "Pedro Luis Lazo",
              img: "http://localhost:8000/src/logos/pedro_luis_lazo.jpg",
              position: "Pitcher",
            },
            {
              id: 3,
              name: "Frank Camilo Morejón",
              img: "http://localhost:8000/src/logos/frank-camilo.jpg",
              position: "Catcher",
            },
          ],
        },
      },
    });
  };

  handleOnClickAdd = (path, serie) => {
    this.props.history.push({ pathname: path, state: { serie } });
  };

  render() {
    // if (this.state.redirect) {
    //   return <Redirect to={this.state.redirect}></Redirect>;
    // }
    const columns = [
      { dataField: "name", text: "Nombre", filter: textFilter() },
      { dataField: "season", text: "Temporada", filter: textFilter() },
      { dataField: "reach", text: "Carácter", filter: textFilter() },
      {
        dataField: "ng",
        text: "Cantidad de juegos",
        filter: numberFilter({
          delay: 1000,
          numberComparators: [Comparator.EQ, Comparator.GT, Comparator.LT],
        }),
      },
      {
        dataField: "nt",
        text: "Cantidad de equipos",
        filter: numberFilter({
          delay: 1000,
          numberComparators: [Comparator.EQ, Comparator.GT, Comparator.LT],
        }),
      },
      { dataField: "winner", text: "Primer lugar", filter: textFilter() },
      { dataField: "loser", text: "Último lugar", filter: textFilter() },
    ];

    // const tableRowEvents = {
    //   onClick: (e, row) => this.props.history.push("/serieForm"),
    // };

    return (
      <Container>
        <Table
          // keyField="id"
          // data={this.state.series}
          // columns={columns}
          // filter={filterFactory()}
          striped
          responsive
          bordered
          hover
        >
          <thead>
            <tr>
              <th>Nombre</th>
              <th>Inicio</th>
              <th>Final</th>
              <th>Carácter</th>
              <th>Cantidad de juegos</th>
              <th>Cantidad de equipos</th>
              <th>Primer lugar</th>
              <th>Último lugar</th>
            </tr>
          </thead>
          <tbody>
            {this.state.series.map((serie) => (
              <tr key={serie.id}>
                <td onClick={() => this.handleOnClick(serie.id, serie.name)}>
                  {serie.name}
                </td>
                <td onClick={() => this.handleOnClick(serie.id, serie.name)}>
                  {serie.seasonStart}
                </td>
                <td onClick={() => this.handleOnClick(serie.id, serie.name)}>
                  {serie.seasonEnd}
                </td>
                <td onClick={() => this.handleOnClick(serie.id, serie.name)}>
                  {serie.reach}
                </td>
                <td onClick={() => this.handleOnClick(serie.id, serie.name)}>
                  {serie.ng}
                </td>
                <td onClick={() => this.handleOnClick(serie.id, serie.name)}>
                  {serie.nt}
                </td>
                <td onClick={() => this.handleOnClick(serie.id, serie.name)}>
                  {serie.winner}
                </td>
                <td onClick={() => this.handleOnClick(serie.id, serie.name)}>
                  {serie.loser}
                </td>
                <DeleteEdit
                  delete={true}
                  onEdit={() => this.handleOnClickAdd("/serieForm", serie)}
                  edit={true}
                  size="sm"
                  space={1}
                  top={2}
                />
              </tr>
            ))}
          </tbody>
        </Table>
        <Add
          text="Agregar Serie"
          onClick={() => this.handleOnClickAdd("/serieForm")}
        />
      </Container>
    );
  }
}

export default Series;
