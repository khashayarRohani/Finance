import React, { SyntheticEvent } from "react";
import "./Card.css";
import { CompanySearch } from "../../company";
import AddPortfolio from "../Portfolio/AddPortfolio/AddPortfolio";
type Props = {
  id: string;
  searchResult: CompanySearch;
  onPortfolioCreate: (e: SyntheticEvent) => void;
};

const Card: React.FC<Props> = (props: Props): JSX.Element => {
  return (
    <div className="card">
      <img
        src="https://images.unsplash.com/photo-1612428978260-2b9c7df20150?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=580&q=80"
        alt="companyLogo"
      />
      <div className="details">
        <h2>
          {props.searchResult.name}({props.searchResult.symbol})
        </h2>
        <p>${props.searchResult.currency}</p>
      </div>
      <p className="info">
        {props.searchResult.exchangeShortName} -
        {props.searchResult.stockExchange}
      </p>
      <AddPortfolio
        onPortfolioCreate={props.onPortfolioCreate}
        symbol={props.searchResult.symbol}
      />
    </div>
  );
};
export default Card;
