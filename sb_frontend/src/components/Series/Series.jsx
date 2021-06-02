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
import { conditionalExpression } from "@babel/types";
// import { BootstrapTable } from "react-bootstrap-table-next";
// import ReactDataTable from "react-datatable-with-bootstrap";

class Series extends Component {
  state = {
    redirect: null,
    deleteRecord: false,
    edited: false,
    series: [],
    allstarteams:[]
  };

  componentDidMount() {
    fetch("https://localhost:44334/api/Serie", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ series: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
      fetch("https://localhost:44334/api/StarPositionPlayerSerie", { mode: "cors" })
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .then((response) => {
        this.setState({ allstarteams: response });
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });
  }

  handleOnDelete = (serie, index) => {
    fetch(
      `https://localhost:44334/api/Serie/${serie.id}/${serie.initDate}/${serie.endDate}`,
      {
        mode: "cors",
        method: "DELETE",
        headers:{"Authorization": "Bearer " + JSON.parse(localStorage.getItem("loggedUser")).jwt_token}
      }
    )
      .then((response) => {
        if (!response.ok) {
          throw Error(response.statusText);
        }
        return response.json();
      })
      .catch(function (error) {
        console.log("Hubo un problema con la petición Fetch:" + error.message);
      });

    let n_series = [...this.state.series];
    n_series.splice(index, 1);

    this.setState({ series: n_series });
  };

  handleOnClick = (id, initDate, endDate, name) => {
    this.props.history.push({
      pathname: "/serie",
      state: {
        serie: {
          id: id,
          initDate: initDate,
          endDate: endDate,
          name: name,
        },
      },
    });
  };

  handleOnClickAdd = (path, serie) => {
    this.props.history.push({ pathname: path, state: { serie } });
  };

  render() {
    const columns = [
      { dataField: "name", text: "Nombre", filter: textFilter() },
      { dataField: "season", text: "Temporada", filter: textFilter() },
      { dataField: "caracter", text: "Carácter", filter: textFilter() },
      {
        dataField: "numberOfGames",
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
            {this.state.series.map((serie, index) => (
              <tr key={serie.id}>
                <td
                  onClick={() =>
                    this.handleOnClick(
                      serie.id,
                      serie.initDate,
                      serie.endDate,
                      serie.name
                    )
                  }
                >
                  {serie.name}
                </td>
                <td
                  onClick={() =>
                    this.handleOnClick(
                      serie.id,
                      serie.initDate,
                      serie.endDate,
                      serie.name
                    )
                  }
                >
                  {new Date(serie.initDate).toLocaleString().split(",")[0]}
                </td>
                <td
                  onClick={() =>
                    this.handleOnClick(
                      serie.id,
                      serie.initDate,
                      serie.endDate,
                      serie.name
                    )
                  }
                >
                  {new Date(serie.endDate).toLocaleString().split(",")[0]}
                </td>
                <td
                  onClick={() =>
                    this.handleOnClick(
                      serie.id,
                      serie.initDate,
                      serie.endDate,
                      serie.name
                    )
                  }
                >
                  {serie.caracterSerie.caracter_Name}
                </td>
                <td
                  onClick={() =>
                    this.handleOnClick(
                      serie.id,
                      serie.initDate,
                      serie.endDate,
                      serie.name
                    )
                  }
                >
                  {serie.numberOfGames}
                </td>
                <td
                  onClick={() =>
                    this.handleOnClick(
                      serie.id,
                      serie.initDate,
                      serie.endDate,
                      serie.name
                    )
                  }
                >
                  {serie.numberOfTeams}
                </td>
                <td
                  onClick={() =>
                    this.handleOnClick(
                      serie.id,
                      serie.initDate,
                      serie.endDate,
                      serie.name
                    )
                  }
                >
                  {serie.winer && serie.winer.name}
                </td>
                <td
                  onClick={() =>
                    this.handleOnClick(
                      serie.id,
                      serie.initDate,
                      serie.endDate,
                      serie.name
                    )
                  }
                >
                  {serie.loser && serie.loser.name}
                </td>
                <DeleteEdit
                  delete={true}
                  onEdit={() => this.handleOnClickAdd("/serieForm", serie)}
                  onDelete={() => this.handleOnDelete(serie, index)}
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
