import React, { SyntheticEvent } from "react";

type Props = {
  symbol: string;
  onPortfolioCreate: (e: SyntheticEvent) => void;
};

const AddPortfolio = (props: Props) => {
  return (
    <>
      <form onSubmit={props.onPortfolioCreate}>
        <input value={props.symbol} readOnly hidden />
        <button type="submit">Add</button>
      </form>
    </>
  );
};

export default AddPortfolio;
