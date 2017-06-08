INSERT INTO TB_FeedTransformation (FeedId, ExecuteOrder, OriginalValue, OriginalColumn, NewValue, NewColumn)
select 1, id, ColumnValue, 'EXT_ID', 'BVSP.'+ColumnValue, 'EXT_ID' from TB_FeedFilter
