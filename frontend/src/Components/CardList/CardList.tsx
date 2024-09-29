import React, { SyntheticEvent } from "react";
import Card from "../Card/Card";
import { CompanySearch } from "../../company";
import { v4 as uuidv4 } from "uuid";
type Props = {
  searchResults: CompanySearch[];
  onPortfolioCreate: (e: SyntheticEvent) => void;
};

const CardList: React.FC<Props> = (props: Props): JSX.Element => {
  return (
    <>
      <div>
        {props.searchResults.length > 0 ? (
          props.searchResults.map((searchResult) => {
            return (
              <Card
                onPortfolioCreate={props.onPortfolioCreate}
                id={searchResult.symbol}
                key={uuidv4()}
                searchResult={searchResult}
              />
            );
          })
        ) : (
          <p className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
            No results!
          </p>
        )}
      </div>
    </>
  );
};

export default CardList;
