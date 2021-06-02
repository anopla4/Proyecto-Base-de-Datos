// import React, { Component } from "react";

// class WebMaster extends Component {
//   state = {};
//   render() {
//     return (
//       <Table
//         // keyField="id"
//         // data={this.state.series}
//         // columns={columns}
//         // filter={filterFactory()}
//         striped
//         responsive
//         bordered
//         hover
//       >
//         <thead>
//           <tr>
//             <th>Nombre</th>
//             <th>Inicio</th>
//             <th>Final</th>
//             <th>Carácter</th>
//             <th>Cantidad de juegos</th>
//             <th>Cantidad de equipos</th>
//             <th>Primer lugar</th>
//             <th>Último lugar</th>
//           </tr>
//         </thead>
//         <tbody>
//           {this.state.series.map((serie, index) => (
//             <tr key={serie.id}>
//               <td
//                 onClick={() =>
//                   this.handleOnClick(
//                     serie.id,
//                     serie.initDate,
//                     serie.endDate,
//                     serie.name
//                   )
//                 }
//               >
//                 {serie.name}
//               </td>
//               <td
//                 onClick={() =>
//                   this.handleOnClick(
//                     serie.id,
//                     serie.initDate,
//                     serie.endDate,
//                     serie.name
//                   )
//                 }
//               >
//                 {new Date(serie.initDate).toLocaleString().split(",")[0]}
//               </td>
//               <td
//                 onClick={() =>
//                   this.handleOnClick(
//                     serie.id,
//                     serie.initDate,
//                     serie.endDate,
//                     serie.name
//                   )
//                 }
//               >
//                 {new Date(serie.endDate).toLocaleString().split(",")[0]}
//               </td>
//               <td
//                 onClick={() =>
//                   this.handleOnClick(
//                     serie.id,
//                     serie.initDate,
//                     serie.endDate,
//                     serie.name
//                   )
//                 }
//               >
//                 {serie.caracterSerie.caracter_Name}
//               </td>
//               <td
//                 onClick={() =>
//                   this.handleOnClick(
//                     serie.id,
//                     serie.initDate,
//                     serie.endDate,
//                     serie.name
//                   )
//                 }
//               >
//                 {serie.numberOfGames}
//               </td>
//               <td
//                 onClick={() =>
//                   this.handleOnClick(
//                     serie.id,
//                     serie.initDate,
//                     serie.endDate,
//                     serie.name
//                   )
//                 }
//               >
//                 {serie.numberOfTeams}
//               </td>
//               <td
//                 onClick={() =>
//                   this.handleOnClick(
//                     serie.id,
//                     serie.initDate,
//                     serie.endDate,
//                     serie.name
//                   )
//                 }
//               >
//                 {serie.winner && serie.winner.name}
//               </td>
//               <td
//                 onClick={() =>
//                   this.handleOnClick(
//                     serie.id,
//                     serie.initDate,
//                     serie.endDate,
//                     serie.name
//                   )
//                 }
//               >
//                 {serie.loser && serie.loser.name}
//               </td>
//               <DeleteEdit
//                 delete={true}
//                 onEdit={() => this.handleOnClickAdd("/serieForm", serie)}
//                 onDelete={() => this.handleOnDelete(serie, index)}
//                 edit={true}
//                 size="sm"
//                 space={1}
//                 top={2}
//               />
//             </tr>
//           ))}
//         </tbody>
//       </Table>
//     );
//   }
// }

// export default WebMaster;
