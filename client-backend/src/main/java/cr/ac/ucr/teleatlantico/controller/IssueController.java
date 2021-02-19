package cr.ac.ucr.teleatlantico.controller;

import java.util.Date;
import java.util.NoSuchElementException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import cr.ac.ucr.teleatlantico.domain.Client;
import cr.ac.ucr.teleatlantico.domain.Issue;
import cr.ac.ucr.teleatlantico.service.IssueService;

@CrossOrigin(origins = "http://localhost:4200")
@RestController
@RequestMapping("/issue")
public class IssueController {

	@Autowired
	private IssueService service;

	@GetMapping("/client/{id}")
	public ResponseEntity<Issue> getIssueByClientId(@PathVariable Integer id) {
		try {
			Issue issue = service.getIssueByClientId(id);
			return new ResponseEntity<Issue>(issue, HttpStatus.OK);
		} catch (NoSuchElementException e) {
			return new ResponseEntity<Issue>(HttpStatus.NOT_FOUND);
		}
	}
	
}
