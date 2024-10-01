import React, { SyntheticEvent } from "react";
import DeletePortfolio from "../DeletePortfolio/DeletePortfolio";
import { Link } from "react-router-dom";

type Props = {
  portfolioValue: string;
  onPortfolioDelete: (e: SyntheticEvent) => void;
};

const CardPortfolio = (props: Props) => {
  return (
    <div className="flex flex-col w-full p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3">
      <Link
        to={`/company/${props.portfolioValue}/company-profile`}
        className="pt-6 text-xl font-bold"
      >
        {props.portfolioValue}
      </Link>
      <DeletePortfolio
        portfolioValue={props.portfolioValue}
        onPortfolioDelete={props.onPortfolioDelete}
      />
    </div>
  );
};

export default CardPortfolio;
