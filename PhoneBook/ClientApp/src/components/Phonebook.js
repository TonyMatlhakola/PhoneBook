import React, { useState, useEffect } from "react";
import Axios from "axios";
import AddContactModal from "./AddContactModal";

function PhoneBook() {
  const [phonBookdata, setPhonBookData] = useState([]);
  const [search, setSearch] = useState(``);
  const url = "http://localhost:5000/api/phonebook";

  useEffect(() => {
    GetPhonebookData();
  }, []);

  const GetPhonebookData = () => {
    return Axios.get(url)
      .then((response) => {
        setPhonBookData(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.log("Error:  " + error);
      });
  };

  return (
    <>
      {phonBookdata &&
        phonBookdata.map((contactEntry, index) => (
          <div key={index}>
            <h4 className="center">{contactEntry.name}</h4>
            <div style={{ marginBottom: "5px" }}>
              <input
                type="text"
                onChange={(e) => setSearch(e.target.value)}
                placeholder="Search Name"
              />
            </div>
            <br />
            <div className="row">
              <div className="column">
                <table className="table">
                  <thead className="thead-dark">
                    <tr>
                      <th scope="col">Name</th>
                      <th scope="col">PhoneNumber</th>
                    </tr>
                  </thead>
                  <tbody>
                    {contactEntry.contactsDetails &&
                      contactEntry.contactsDetails
                        .filter((li) =>
                          li.name
                            .toString()
                            .toLowerCase()
                            .includes(search.toString().toLowerCase())
                        )
                        .map((contact) => {
                          return (
                            <tr key={contact.id}>
                              <td>{contact.name}</td>
                              <td>{contact.phoneNumber}</td>
                            </tr>
                          );
                        })}
                  </tbody>
                </table>
              </div>
              <div className="column">
                <AddContactModal />
              </div>
            </div>
          </div>
        ))}
    </>
  );
}

export default PhoneBook;
