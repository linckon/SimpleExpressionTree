public static class EntityByExample<TEntity> where TEntity : class
{
	public static TEntity GetEntityByEntityId(DataContext ctx, string objId)
	{
		var id = int.MinValue;
		TypeConverter.StringToType(objId, ref id);
		var table = ctx.GetTable<TEntity>();
		var primaryKey =
			ctx.Mapping.GetMetaType(typeof (TEntity))
			   .DataMembers.Single(member => member.IsPrimaryKey)
			   .Member.Name;
		var entity = Expression.Parameter(typeof (TEntity), "entity");
		var lambda = Expression.Lambda<Func<TEntity, bool>>(
			Expression.Equal(Expression.PropertyOrField(entity, primaryKey),
							 Expression.Constant(id, typeof (int))), entity);
		return table.Single(lambda);
	}
}