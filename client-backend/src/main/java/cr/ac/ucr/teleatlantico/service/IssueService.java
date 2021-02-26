package cr.ac.ucr.teleatlantico.service;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cr.ac.ucr.teleatlantico.domain.Client;
import cr.ac.ucr.teleatlantico.domain.Issue;
import cr.ac.ucr.teleatlantico.repository.IssueRepository;

@Service
@Transactional
public class IssueService {

	@Autowired
	private IssueRepository repository;
	
	public List<Issue> getIssueByClientId(int id) {
		return repository.getIssueByIdClient(id);
	}

	public Issue save(Issue issue, String clientEmail) {
		repository.saveSP(issue.getDescription(), issue.getService().getServiceId(), clientEmail);
		return repository.getLastInsertIssue();
	}

	public Set<Issue> getByEmail(String email) {
		Client client = repository.findByEmail(email);
		if(client == null)
			return new HashSet<Issue>();
		return client.getIssues();
	}

	public void delete(int issueId) {
		repository.deleteById(issueId);
	}
	
	
}
