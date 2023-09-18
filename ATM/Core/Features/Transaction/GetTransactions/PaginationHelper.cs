namespace ATM.Core.Features.Transaction.GetTransactions
{
    public static class PaginationHelper
    {
        public static List<List<T>> Paginate<T>(List<T> items,int pageSize = 10 )
        {
            var totalPages = (int)Math.Ceiling((double)items.Count / pageSize);
            var paginatedList = new List<List<T>>();

            for (var page = 0; page < totalPages; page++)
            {
                var pageItems = items.Skip(page * pageSize).Take(pageSize).ToList();
                paginatedList.Add(pageItems);
            }

            return paginatedList;
        }
    }
}
