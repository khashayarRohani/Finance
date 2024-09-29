import React, { SyntheticEvent } from "react";
import CardPortfolio from "../CardPortfolio/CardPortfolio";

type Props = {
  portfolioValues: string[];
  onPortfolioDelete: (e: SyntheticEvent) => void;
};

const ListPortfolio = (props: Props) => {
  return (
    <>
      <h3>My Portfolio</h3>
      <ul>
        {props.portfolioValues &&
          props.portfolioValues.map((portfolioValue) => {
            return (
              <CardPortfolio
                portfolioValue={portfolioValue}
                onPortfolioDelete={props.onPortfolioDelete}
              />
            );
          })}
      </ul>
    </>
  );
};

export default ListPortfolio;
