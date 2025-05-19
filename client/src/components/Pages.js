import { Pagination } from "react-bootstrap";

export default function Pages({ totalCount, limit, page, handlePage }) {
  const pageCount = Math.ceil(totalCount / limit);

  if (pageCount <= 1) return null;

  const fixedStyle = {
    minWidth: "40px",
    textAlign: "center",
    padding: "0.375rem 0",
  };

  const items = [];

  items.push(
    <Pagination.Prev
      key="prev"
      onClick={() => handlePage(page - 1)}
      disabled={page === 1}
      style={fixedStyle}
    />
  );

  const pagesToShow = [];

  if (pageCount <= 3) {
    for (let i = 1; i <= pageCount; i++) {
      pagesToShow.push(i);
    }
  } else {
    if (page <= 2) {
      pagesToShow.push(1, 2, 3);
    } else if (page >= pageCount - 1) {
      pagesToShow.push(pageCount - 2, pageCount - 1, pageCount);
    } else {
      pagesToShow.push(page - 1, page, page + 1);
    }
  }

  pagesToShow.forEach((pg) => {
    items.push(
      <Pagination.Item
        key={pg}
        active={page === pg}
        onClick={() => handlePage(pg)}
        style={fixedStyle}
      >
        {pg}
      </Pagination.Item>
    );
  });

  items.push(
    <Pagination.Next
      key="next"
      onClick={() => handlePage(page + 1)}
      disabled={page === pageCount}
      style={fixedStyle}
    />
  );

  return <Pagination className="mt-5">{items}</Pagination>;
}
