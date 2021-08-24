import React, { useState } from "react";
import Axios from "axios";

const AddContactModal = () => {
  const [contactName, setName] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const url = "http://localhost:5000/api/phonebook";

  const handleSubmit = (e) => {
    e.preventDefault();

    let data = {
      Name: contactName,
      phoneNumber: phoneNumber,
    };

    console.log(data);

    const headers = {
      "Content-Type": "multipart/form-data",
    };

    const Config = {
        headers,
      mode: "cors",
    };

    Axios.post(url, data, headers, Config)
      .then((response) => {
        ResfreshPage();
        console.log(response);
        alert("You have successfully added: "+ contactName);

      })
      .catch((error) => {
        console.log("Error:  " + error);
      });
  };

  const ResfreshPage =() => {
    window.location.reload();
      }

  return (
    <div style={{ float: "right" }}>
      <form action="" onSubmit={(e) => handleSubmit(e)}>
        <h2 className="center">Add Contact Details</h2>
        <div>
          <h5>Name</h5>
          <input
            type="text"
            name="name"
            defaultValue=""
            onChange={(e) => setName(e.target.value)}
            required
          />
          <h5>Phone Number</h5>
          <input
            type="text"
            name="phoneNumber"
            defaultValue=""
            onChange={(e) => setPhoneNumber(e.target.value)}
            required
          />
        </div>
        <br />

        <button type="submit" className="button button-black">
          Add
        </button>
      </form>
    </div>
  );
};
export default AddContactModal;
