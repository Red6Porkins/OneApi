using SDK.Contracts;
using SDK.Enums;

namespace SDK
{
    public static class FilterBuilder
    {
        public static string BuildQueryString(List<QueryParameter> Params)
        {
            var QueryString = "limit=10";
            Params?.Where(x => x.Filter != FilterEnum.Include && x.Filter != FilterEnum.Exclude).ToList().ForEach(x =>
            {
                switch (x.Filter)
                {
                    case FilterEnum.Equals:
                        QueryString += $"&{x.Field}={x.Value}";
                        break;

                    case FilterEnum.NotEquals:
                        QueryString += $"&{x.Field}!={x.Value}";
                        break;

                    case FilterEnum.RegEx:
                        QueryString += $"&{x.Field}=/{x.Value}/i";
                        break;

                    case FilterEnum.NotRegEx:
                        QueryString += $"&{x.Field}!=/{x.Value}/i";
                        break;

                    case FilterEnum.Less:
                        QueryString += $"&{x.Field}<{x.Value}";
                        break;

                    case FilterEnum.LessOrEqual:
                        QueryString += $"&{x.Field}<={x.Value}";
                        break;

                    case FilterEnum.Greater:
                        QueryString += $"&{x.Field}>{x.Value}";
                        break;

                    case FilterEnum.GreaterOrEqual:
                        QueryString += $"&{x.Field}>={x.Value}";
                        break;
                }
            });

            Params
                ?.Where(x => x.Filter == FilterEnum.Include)
                .GroupBy(x => x.Field)
                .ToList().ForEach(x =>
                {
                    QueryString += $"&{x.Key}={string.Join(",", Params.Where(y => y.Filter == FilterEnum.Include && y.Field == x.Key).Select(x => x.Value).ToList())}";
                });

            Params
                ?.Where(x => x.Filter == FilterEnum.Exclude)
                .GroupBy(x => x.Field)
                .ToList().ForEach(x =>
                {
                    QueryString += $"&{x.Key}={string.Join(",", Params.Where(y => y.Filter == FilterEnum.Exclude && y.Field == x.Key).Select(x => x.Value).ToList())}";
                });

            return QueryString;
        }
    }
}
