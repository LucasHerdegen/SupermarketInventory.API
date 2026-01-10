import { useState } from "react";
import type { Product } from "./producto";
import Table from './Table';

export default function SearchProducts({ products }: SearchProductsProps)
{
    const [filterString, setFilterString] = useState('');

    return (
        <div className="container">
            <h3> Ingrese una categoria </h3>
            <input type="text" onChange={e => setFilterString(e.target.value)}/>
            <Table products={products.filter(p => p.categoryName.toLowerCase().includes(filterString))}/>
        </div>
    )
}

interface SearchProductsProps
{
    products: Product[];
}