import React from 'react';
import { Instrument } from '../viewModels/instrument';
import { IRatingsServiceClient, RatingsServiceClient } from '../apiClient/ratingsServiceClient';
import { AgGridReact } from 'ag-grid-react'; // React Data Grid Component
import { ColDef } from 'ag-grid-community';
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the Data Grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the Data Grid
import { Container } from '@mui/material';
import config from '../config/appConfig';

const InstrumentRatings: React.FC = () => {

    // Row Data: The data to be displayed.
    const [rowData, setRowData] = React.useState<Instrument[]>([]);

    const [loading, setLoading] = React.useState(false);
    const [error, setError] = React.useState<string>();

    const instrumentColumnDefs: ColDef[] = [

        { field: 'name', headerName: 'Name', sortable: true, filter: 'agTextColumnFilter' },
        { field: 'isin', headerName: 'ISIN', sortable: true, filter: 'agTextColumnFilter' },
        { field: 'sedol', headerName: 'SEDOL', sortable: true, filter: 'agTextColumnFilter' },
        { field: 'instrumentType', headerName: 'Type', sortable: true, filter: 'agTextColumnFilter' },
        { field: 'baseCurrency', headerName: 'Currency', sortable: true, filter: 'agSetColumnFilter' },
        { field: 'moodysRating', headerName: "Moody's Rating", sortable: true, filter: 'agTextColumnFilter' },
        { field: 'analystRating', headerName: 'Analyst Rating', sortable: true, filter: 'agTextColumnFilter' }
    ];

    React.useEffect(() => {
        const fetchRatings = async () => {

            setLoading(true);
            const ratingsServiceClient: IRatingsServiceClient = new RatingsServiceClient();
            try {
                const ratingsData = await ratingsServiceClient.fetchInstrumentRating()

                setRowData(ratingsData);
                setError("");
            }
            catch (err) {
                setRowData([]);
                console.warn("Warning about an error is being shown to the user, See next log item for details")
                console.error(err);
                setError(`There was an error getting data from the server. Please ensure the API is running on ${config.apiBaseUrl}. Please contact tech team for more info.`)
            }
            finally {
                setLoading(false);
            }
        }

        fetchRatings();
    }, [error]);

    return (
        <div className='h-full'>

            <h2 className=' p-4 bg-slate-50 font-semibold'>Security Ratings</h2>
            <Container maxWidth="xl">

                <div
                    className="ag-theme-quartz pt-4" // applying the Data Grid theme
                    style={{ height: 500 }} // the Data Grid will fill the size of the parent container
                >
                    {
                        loading && (
                            <div className="grid min-h-[140px] w-full place-items-center overflow-x-scroll rounded-lg p-6 lg:overflow-visible">
                                <svg className="text-gray-300 animate-spin" viewBox="0 0 64 64" fill="none" xmlns="http://www.w3.org/2000/svg"
                                    width="100" height="100">
                                    <path
                                        d="M32 3C35.8083 3 39.5794 3.75011 43.0978 5.20749C46.6163 6.66488 49.8132 8.80101 52.5061 11.4939C55.199 14.1868 57.3351 17.3837 58.7925 20.9022C60.2499 24.4206 61 28.1917 61 32C61 35.8083 60.2499 39.5794 58.7925 43.0978C57.3351 46.6163 55.199 49.8132 52.5061 52.5061C49.8132 55.199 46.6163 57.3351 43.0978 58.7925C39.5794 60.2499 35.8083 61 32 61C28.1917 61 24.4206 60.2499 20.9022 58.7925C17.3837 57.3351 14.1868 55.199 11.4939 52.5061C8.801 49.8132 6.66487 46.6163 5.20749 43.0978C3.7501 39.5794 3 35.8083 3 32C3 28.1917 3.75011 24.4206 5.2075 20.9022C6.66489 17.3837 8.80101 14.1868 11.4939 11.4939C14.1868 8.80099 17.3838 6.66487 20.9022 5.20749C24.4206 3.7501 28.1917 3 32 3L32 3Z"
                                        stroke="currentColor" stroke-width="5" stroke-linecap="round" stroke-linejoin="round"></path>
                                    <path
                                        d="M32 3C36.5778 3 41.0906 4.08374 45.1692 6.16256C49.2477 8.24138 52.7762 11.2562 55.466 14.9605C58.1558 18.6647 59.9304 22.9531 60.6448 27.4748C61.3591 31.9965 60.9928 36.6232 59.5759 40.9762"
                                        stroke="currentColor" stroke-width="5" stroke-linecap="round" stroke-linejoin="round" className="text-gray-900">
                                    </path>
                                </svg>
                            </div>

                        )
                    }

                    {error && (
                        <div className="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded relative p-1 mb-5 mt-2" role="alert">
                            <strong className="font-bold">Server Error! </strong>
                            <span className="block sm:inline">{error}</span>
                            <span className="absolute top-0 bottom-0 right-0 px-4 py-3">
                                <svg className="fill-current h-6 w-6 text-red-500" role="button" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20"><title>Close</title><path d="M14.348 14.849a1.2 1.2 0 0 1-1.697 0L10 11.819l-2.651 3.029a1.2 1.2 0 1 1-1.697-1.697l2.758-3.15-2.759-3.152a1.2 1.2 0 1 1 1.697-1.697L10 8.183l2.651-3.031a1.2 1.2 0 1 1 1.697 1.697l-2.758 3.152 2.758 3.15a1.2 1.2 0 0 1 0 1.698z" /></svg>
                            </span>
                        </div>
                    )}

                    {!loading && (
                        <AgGridReact
                            enableCellTextSelection={true}
                            rowData={rowData}
                            columnDefs={instrumentColumnDefs}
                            defaultColDef={{ flex: 1, resizable: true }}
                        />
                    )}
                </div>

                {
                    /* 
                    
                    Grids are great and offer a lot of in built functionality so I have preferred to use a grid. 
                    If we do not want to use grids etc, we can build it ourselved using basic table or flex grids 
        
                    Here is an example of a simple table to displauy the report: 
        
    
                        <div className="h-full">
                            <table border={1} className=' table-auto shadow-lg bg-white m-4 p-10'>
                                <thead>
                                    <tr>
                                        <th className='bg-blue-100 border text-left px-8 py-4'></th>
                                        <th className='bg-blue-100 border text-left px-8 py-4'>ISIN</th>
                                        <th className='bg-blue-100 border text-left px-8 py-4'>SEDOL</th>
                                        <th className='bg-blue-100 border text-left px-8 py-4'>Name</th>
                                        <th className='bg-blue-100 border text-left px-8 py-4'>Type</th>
                                        <th className='bg-blue-100 border text-left px-8 py-4'>Base Currency</th>
                                        <th className='bg-blue-100 border text-left px-8 py-4'>Moody's Rating</th>
                                        <th className='bg-blue-100 border text-left px-8 py-4'>Analyst Rating</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {rowData.map((item: Instrument, index: number) => (
                                        <tr key={index}>
                                            <td className='border px-8 py-4'>{index + 1}</td>
                                            <td className='border px-8 py-4'>{item.isin}</td>
                                            <td className='border px-8 py-4'>{item.sedol}</td>
                                            <td className='border px-8 py-4'>{item.name}</td>
                                            <td className='border px-8 py-4'>{item.instrumentType}</td>
                                            <td className='border px-8 py-4'>{item.baseCurrency}</td>
                                            <td className='border px-8 py-4'>{item.moodysRating}</td>
                                            <td className='border px-8 py-4'>{item.analystRating}</td>
                                        </tr>
                                    ))}
                                    {rowData && rowData.length === 0 &&
                                        (
                                            <tr>
                                                <td colSpan={8}>No data found</td>
                                            </tr>
                                        )}
                                </tbody>
                            </table> 
                        </div>
                         
                    */
                }
            </Container>
        </div>
    );
};
export default InstrumentRatings;