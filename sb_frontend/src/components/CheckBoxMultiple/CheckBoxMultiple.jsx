// import React, { Component, Children, PropTypes } from "react";
// // import Selectly from "selectly";
// // const { Select, Option, utils } = Selectly;
// const { getToggledOptions } = utils;

// class CheckboxOption extends Component {
//   render() {
//     const { value, isChecked, children } = this.props;
//     return (
//       <Option className="react-select-option" value={value}>
//         <input
//           type="checkbox"
//           className="react-select-option__checkbox"
//           defaultValue={null}
//           checked={isChecked}
//         />
//         <div className="react-select-option__label">{children}</div>
//       </Option>
//     );
//   }
// }

// class CheckboxMultiSelect extends Component {
//   constructor(props) {
//     super(props);
//     this.state = {
//       defaultValue: "",
//       currentValues: this.props.currentValues,
//     };
//     this._handleChange = this._handleChange.bind(this);
//   }

//   _handleChange(value) {
//     this.setState({
//       currentValues: getToggledOptions(this.state.currentValues, value),
//     });
//   }

//   render() {
//     const { defaultValue, currentValues } = this.state;

//     return (
//       <Select classPrefix="react-select" multiple onChange={this._handleChange}>
//         <button className="react-select-trigger">
//           {currentValues.length > 0 ? currentValues.join(", ") : defaultValue}
//         </button>
//         <div className="react-select-menu">
//           <ul className="react-select-options">
//             {this.props.values.map((v) => (
//               <CheckboxOption
//                 value={v}
//                 isChecked={currentValues.indexOf(v.label) > -1}
//               >
//                 {v}
//               </CheckboxOption>
//             ))}
//           </ul>
//         </div>
//       </Select>
//     );
//   }
// }
// export default CheckboxMultiSelect;
