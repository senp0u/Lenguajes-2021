package cr.ac.ucr.teleatlantico.controller;

import java.security.Principal;

import java.util.List;
import java.util.NoSuchElementException;
import java.util.Set;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.sun.jdi.InternalException;

import cr.ac.ucr.teleatlantico.domain.Issue;
import cr.ac.ucr.teleatlantico.dto.Converter;
import cr.ac.ucr.teleatlantico.dto.IssueDTO;
import cr.ac.ucr.teleatlantico.service.IssueService;

@CrossOrigin(origins = "http://localhost:4200")
@RestController
@RequestMapping("/issue")
public class IssueController {

	@Autowired
	private IssueService service;
	
	private final String url = "http://localhost:57943";
	
	@GetMapping("/client/{id}")
	public ResponseEntity<List<Issue>> getIssueByClientId(@PathVariable Integer id) {
		try {
			List<Issue> issues = service.getIssueByClientId(id);
			return new ResponseEntity<List<Issue>>(issues, HttpStatus.OK);
		} catch (NoSuchElementException e) {
			return new ResponseEntity<List<Issue>>(HttpStatus.NOT_FOUND);
		}
	}
	
	@GetMapping("/get")
	@ResponseBody
	public ResponseEntity<Set<Issue>> get(Principal principal) {
		try {
			Set<Issue> issues = service.getByEmail(principal.getName());
			return new ResponseEntity<Set<Issue>>(issues, HttpStatus.OK);
		} catch (NoSuchElementException e) {
			return new ResponseEntity<Set<Issue>>(HttpStatus.NOT_FOUND);
		}
	}
	
	@PostMapping(value = "/addIssue", consumes="application/json")
	@ResponseBody
	public ResponseEntity<Issue> addIssue(@RequestBody Issue issue, Principal principal) throws JsonProcessingException {
		Issue newIssue = null;
		try {
			newIssue = service.save(issue, principal.getName());
			Converter converter = new Converter();
			IssueDTO issueDTO = converter.toIssueDTO(newIssue);
			RestTemplate restTemplate = new RestTemplate();
			HttpHeaders headers = new HttpHeaders();
			headers.setContentType(MediaType.APPLICATION_JSON);
			HttpEntity<IssueDTO> httpEntity = new HttpEntity<>(issueDTO, headers);
			boolean result = restTemplate.postForObject(url+"/api/Issue", issueDTO, Boolean.class);
			if(!result)
				throw new InternalException();
		} catch (Exception e) {
			if(newIssue != null)
				service.delete(newIssue.getIssueId());
			throw new InternalException();
		}
		return new ResponseEntity<Issue>(newIssue, HttpStatus.OK);
	}
	
	@PutMapping(value = "/update", consumes="application/json")
	public void update(@RequestBody IssueDTO issueDTO) {
		System.out.print(issueDTO);
	}
	
}
