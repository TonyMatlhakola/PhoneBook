import React from "react";
import { Route } from "react-router";
import PhonebookData from "./components/Phonebook";
import  Layout  from './components/Layout';
import "./custom.css";

const App = () => {
  return (
    <Layout>
      <Route exact path="/" component={PhonebookData} />
    </Layout>
  );
};

export default App;
