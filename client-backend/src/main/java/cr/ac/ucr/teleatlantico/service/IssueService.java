package cr.ac.ucr.teleatlantico.service;

import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cr.ac.ucr.teleatlantico.repository.IssueRepository;

@Service
@Transactional
public class IssueService {

	@Autowired
	private IssueRepository issueRepository;
	
	
}
