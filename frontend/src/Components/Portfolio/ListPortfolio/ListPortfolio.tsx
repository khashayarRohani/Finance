import React from "react";
import CardPortfolio from "../CardPortfolio/CardPortfolio";

type Props = {
  portfolioValues: string[];
};

const ListPortfolio = (props: Props) => {
  return (
    <>
      <h3>My Portfolio</h3>
      <ul>
        {props.portfolioValues &&
          props.portfolioValues.map((portfolioValue) => {
            return <CardPortfolio portfolioValue={portfolioValue} />;
          })}
      </ul>
    </>
  );
};

export default ListPortfolio;
