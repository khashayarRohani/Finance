import React, { SyntheticEvent } from "react";
import "./Card.css";
import { CompanySearch } from "../../company";
import AddPortfolio from "../Portfolio/AddPortfolio/AddPortfolio";
import { Link } from "react-router-dom";
type Props = {
  id: string;
  searchResult: CompanySearch;
  onPortfolioCreate: (e: SyntheticEvent) => void;
};

const Card: React.FC<Props> = (props: Props): JSX.Element => {
  return (
    <div
      className="flex flex-col items-center justify-between w-full p-6 bg-slate-100 rounded-lg md:flex-row"
      key={props.id}
      id={props.id}
    >
      <Link
        to={`/company/${props.searchResult.symbol}`}
        className="font-bold text-center text-black md:text-left"
      >
        {props.searchResult.name} ({props.searchResult.symbol})
      </Link>
      <p className="text-black">{props.searchResult.currency}</p>
      <p className="font-bold text-black">
        {props.searchResult.exchangeShortName} -{" "}
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
