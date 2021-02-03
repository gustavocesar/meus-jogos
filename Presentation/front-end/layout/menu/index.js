import Link from "next/link";

export default function Menu() {
  return (
    <div className="grid">
      <Link href="/">
        <a>
          <strong>Home</strong>
        </a>
      </Link>
      &nbsp;&nbsp;|&nbsp;&nbsp;
      <Link href="/amigos">
        <a>Amigos</a>
      </Link>
      &nbsp;&nbsp;|&nbsp;&nbsp;
      <Link href="/jogos">
        <a>Jogos</a>
      </Link>
      &nbsp;&nbsp;|&nbsp;&nbsp;
      <Link href="/emprestimos">
        <a>Empréstimos</a>
      </Link>
    </div>
  );
}
