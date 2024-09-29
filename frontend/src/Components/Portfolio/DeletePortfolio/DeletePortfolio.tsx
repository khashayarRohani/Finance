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
        <button className="block w-full py-3 text-white duration-200 border-2 rounded-lg bg-red-500 hover:text-red-500 hover:bg-white border-red-500">
          X
        </button>
      </form>
    </>
  );
};

export default DeletePortfolio;
