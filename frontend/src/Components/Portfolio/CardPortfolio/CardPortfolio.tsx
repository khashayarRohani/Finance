import React from "react";

type Props = { portfolioValue: string };

const CardPortfolio = (props: Props) => {
  return (
    <>
      <h4>{props.portfolioValue}</h4>
      <button>X</button>
    </>
  );
};

export default CardPortfolio;
