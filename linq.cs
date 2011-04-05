		/// <summary>Gets all contracts in the batch</summary>
		/// <returns>Dictionary of ContractID, ContractReference</returns>
		public Dictionary<int, string> ListOfContracts () {
			using (DataContext db = Common.DataContext()) {
				return db.contracts
					.Where(c => c.modified_by == User.UserID && !c.finalized_on.HasValue)
					.OrderBy(c => c.id)
					.Select(c => new { c.id, c.contract_reference })
					.ToDictionary(k => k.id, v => v.contract_reference);
			}
		}