package cr.ac.ucr.teleatlantico.dto;

import java.util.Date;

import cr.ac.ucr.teleatlantico.domain.Issue;

public class Converter {
	
	public IssueDTO toIssueDTO(Issue issue) {
		IssueDTO issueDTo = new IssueDTO(
					0,
					issue.getDescription(),
					issue.getStatus(),
					"Bajo",
					issue.getService().getServiceId(),
					null,
					issue.getIssueId(),
					null,
					null
				);
		return issueDTo;
	}
}
