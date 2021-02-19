package cr.ac.ucr.teleatlantico.service;

import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cr.ac.ucr.teleatlantico.domain.Issue;
import cr.ac.ucr.teleatlantico.repository.IssueRepository;

import java.util.List;

@Service
@Transactional
public class IssueService {

	@Autowired
	private IssueRepository repository;
	


	public Issue save(Issue issue) {
		return repository.save(issue);
	}

	public List<Issue> getIssueByClientId(int id) {
		return repository.getIssueByIdClient(id);
	}
}
