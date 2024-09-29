import React, { SyntheticEvent } from "react";

type Props = {
  onPortfolioDelete: (e: SyntheticEvent) => void;
  portfolioValue: string;
};

const DeletePortfolio = (props: Props) => {
  return (
    <>
      <form onSubmit={props.onPortfolioDelete}>
        <input hidden value={props.portfolioValue} />
        <button type="submit">X</button>
      </form>
    </>
  );
};

export default DeletePortfolio;
