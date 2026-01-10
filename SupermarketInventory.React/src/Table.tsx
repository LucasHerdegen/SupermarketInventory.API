import type { Producto } from "./producto";
import Row from "./Row";

export default function Table({products}: TableProps)
{
    return (
        <div className="table-responsive">
            <table className="table table-striped table-hover">
                <thead>
                    <tr>
                        <th scope="col"> ID </th>
                        <th scope="col"> Name </th>
                        <th scope="col"> Price </th>
                        <th scope="col"> Stock </th>
                        <th scope="col"> Category </th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(p => <Row key={p.id} product={p} />)}
                </tbody>
            </table>
        </div>
    )
}

interface TableProps
{
    products: Producto[]
}