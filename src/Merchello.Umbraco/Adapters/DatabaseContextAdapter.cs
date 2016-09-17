﻿namespace Merchello.Umbraco.Adapters
{
    using Merchello.Core;
    using Merchello.Core.Persistence;
    using Merchello.Core.Persistence.Querying;

    using NPoco;

    using global::Umbraco.Core;

    /// <summary>
    /// Represents an adapter for Umbraco's Database context which is used as Merchello's database factory.
    /// </summary>
    /// <remarks>
    /// This allows Umbraco to manage the database instances, retries etc. between various threads or the HttpContext.
    /// Essentially this lets Umbraco do all the work for providing the database.
    /// </remarks>
    internal sealed class DatabaseContextAdapter : IDatabaseFactory
    {
        /// <summary>
        /// Umbraco's database context.
        /// </summary>
        private readonly DatabaseContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContextAdapter"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// Umbraco's database context.
        /// </param>
        /// <param name="queryFactory">
        /// Merchello's query factory.
        /// </param>
        public DatabaseContextAdapter(DatabaseContext dbContext, IQueryFactory queryFactory)
        {
            Ensure.ParameterNotNull(dbContext, nameof(dbContext));
            Ensure.ParameterNotNull(queryFactory, nameof(queryFactory));

            _dbContext = dbContext;

            this.QueryFactory = queryFactory;
        }

        /// <summary>
        /// Gets a value indicating whether the database is configured.
        /// </summary>
        public bool Configured
        {
            get
            {
                return _dbContext.IsDatabaseConfigured;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can a connection can be made to the database.
        /// </summary>
        public bool CanConnect
        {
            get
            {
                return _dbContext.CanConnect;
            }
        }

        /// <summary>
        /// Gets the Merchello's Query Factory.
        /// </summary>
        /// <remarks>
        /// We need our own query factory here since we have our own model mappers that Umbraco
        /// does not know anything about.
        /// </remarks>
        public IQueryFactory QueryFactory { get; }

        /// <summary>
        /// Gets the database from Umbraco's DatabaseContext.
        /// </summary>
        /// <returns>
        /// The <see cref="Database"/>.
        /// </returns>
        public Database GetDatabase()
        {
            return _dbContext.Database;
        }

        /// <summary>
        /// Disposes resources.
        /// </summary>
        public void Dispose()
        {
            // Handled by the DatabaseContext
        }
    }
}